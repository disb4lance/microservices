using Entities.models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.configurations
{
    public class CurtainsConfigure : IEntityTypeConfiguration<curtains>
    {
        public void Configure(EntityTypeBuilder<curtains> builder)
        {
            builder.HasData
            (
                new curtains
                {
                    id = Guid.NewGuid(),
                    name = "Портьера велюр Марсель",
                    price = 5200,
                    description = "Портьера велюр Марсель — это элегантные шторы из высококачественного велюра, " +
                    "идеально подходящие для создания уютной атмосферы в вашем доме. Шторы прекрасно блокируют свет и сохраняют тепло.",
                    matherial = "Велюр",
                    color = "Бежевый",
                    height = 150,
                    width = 260,
                    ImageUrl = "https://storage.yandexcloud.net/web-cterx/76584172-fb7e-11ec-80d9-002590843481_1.jpg"
                },
                new curtains
                {
                    id = Guid.NewGuid(),
                    name = "Шторы Neula",
                    price = 3500,
                    description = "Шторы Neula сочетают в себе современный дизайн и высокую функциональность. Эти бежевые шторы добавят стильный акцент вашему интерьеру, блокируя яркий свет.",
                    matherial = "Лен",
                    color = "Бежевый",
                    height = 160,
                    width = 270,
                    ImageUrl = "https://storage.yandexcloud.net/web-cterx/delfa_shtora_gura_azul_548_015_interior.jpg"
                },
                new curtains
                {
                    id = Guid.NewGuid(),
                    name = "Шторы Dubley",
                    price = 2800,
                    description = "Шторы Dubley — это стильное решение для вашего интерьера. Они прекрасно смотрятся в любом помещении и создают атмосферу уюта и комфорта.",
                    matherial = "Хлопок",
                    color = "Зеленый",
                    height = 150,
                    width = 250,
                    ImageUrl = "https://storage.yandexcloud.net/web-cterx/delfa_shtora_gura_fango_548_060_interior.jpg"
                },
                new curtains
                {
                    id = Guid.NewGuid(),
                    name = "Шторы Neula2",
                    price = 4000,
                    description = "Эти серые шторы Neula обеспечивают отличную изоляцию от света и шума, а также добавляют элегантность в любое помещение.",
                    matherial = "Вискоза",
                    color = "Серый",
                    height = 160,
                    width = 280,
                    ImageUrl = "https://storage.yandexcloud.net/web-cterx/delfa_shtora_neula_beige_interior.jpg"
                },
                new curtains
                {
                    id = Guid.NewGuid(),
                    name = "Шторы Gura",
                    price = 3200,
                    description = "Шторы Gura привнесут утонченность и стиль в ваш дом. Они идеально подойдут для гостиной или спальни.",
                    matherial = "Полиэстер",
                    color = "Серый",
                    height = 140,
                    width = 270,
                    ImageUrl = "https://storage.yandexcloud.net/web-cterx/delfa_shtora_neula_gris_549_070_interior.jpg"
                },
                new curtains
                {
                    id = Guid.NewGuid(),
                    name = "Шторы Gura2",
                    price = 3100,
                    description = "Элегантные шторы Gura в цвете кофе с молоком — идеальное решение для тех, кто ценит тепло и уют в интерьере.",
                    matherial = "Вискоза",
                    color = "Кофе с молоком",
                    height = 150,
                    width = 260,
                    ImageUrl = "https://storage.yandexcloud.net/web-cterx/delfa_shtori_dubley_verde_546_080_interior.jpg"
                }
            );
        }
    }

}
