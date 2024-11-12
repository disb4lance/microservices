using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.TransferObjects;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Data;
using System.Security.Cryptography;


namespace Services
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        //private readonly JwtConfiguration _jwtConfiguration;
        private User? _user;

        public AuthenticationService(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            //_jwtConfiguration = _configuration.Value;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            if (!result)
            {
                // Можно обработать ошибку здесь
                throw new UnauthorizedAccessException("Неправильное имя пользователя или пароль.");
            }

                return result;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new Exception();
            _user = user;
            return await CreateToken(populateExp: false);
        }
        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials(); // Получает ключ для подписи токена.
            var claims = await GetClaims(); // Получает список claims (утверждений) пользователя, которые будут добавлены в токен.
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims); // Создаёт объект JWT токена с указанными параметрами.
            var refreshToken = GenerateRefreshToken(); // Генерирует refresh токен для обновления access токена.

            _user.RefreshToken = refreshToken; // Устанавливает refresh токен для текущего пользователя.

            if (populateExp) // Если флаг populateExp равен true, устанавливается срок действия refresh токена на 7 дней.
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user); // Обновляет пользователя в базе данных с новым refresh токеном.

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions); // Преобразует `tokenOptions` в строковый формат токена.

            return new TokenDto(accessToken, refreshToken); // Возвращает объект `TokenDto` с access и refresh токенами.
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")); // Получает секретный ключ из переменной окружения и конвертирует в байты.
            var secret = new SymmetricSecurityKey(key); // Создаёт симметричный ключ безопасности.
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256); // Создаёт объект `SigningCredentials` с алгоритмом HMAC-SHA256.
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()) // Claim с ID пользователя
            };
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
 List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings"); // Получает настройки JWT из конфигурации.

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"], // Задаёт издателя токена (должен совпадать с validIssuer в конфигурации).
                audience: jwtSettings["validAudience"], // Задаёт аудиторию токена (validAudience).
                claims: claims, // Добавляет список claims (утверждений) пользователя.
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])), // Устанавливает срок действия токена.
                signingCredentials: signingCredentials // Устанавливает подпись токена.
            );
            return tokenOptions;
        }


        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32]; // Массив для случайных байтов.
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber); // Заполняет массив случайными байтами.
                return Convert.ToBase64String(randomNumber); // Конвертирует массив в строку Base64.
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings"); // Получает настройки JWT.

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true, // Проверяет аудиторию токена.
                ValidateIssuer = true, // Проверяет издателя токена.
                ValidateIssuerSigningKey = true, // Проверяет ключ для подписи токена.
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))), // Ключ безопасности для проверки подписи.
                ValidateLifetime = true, // Проверяет срок действия токена.
                ValidIssuer = jwtSettings["validIssuer"], // Задаёт допустимого издателя.
                ValidAudience = jwtSettings["validAudience"] // Задаёт допустимую аудиторию.
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken); // Проверяет токен и возвращает `ClaimsPrincipal`.

            var jwtSecurityToken = securityToken as JwtSecurityToken; // Преобразует токен в JWT.
            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token"); // Если токен некорректен или алгоритм подписи не соответствует HMAC-SHA256, выбрасывает исключение.
            }
            return principal; // Возвращает `ClaimsPrincipal`.
        }


    }
}
