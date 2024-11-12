﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.TransferObjects
{
    public record UserForRegistrationDto
    {

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        public string? ConfirmPassword { get; init; }
        public string? Email { get; init; }

    }
}
