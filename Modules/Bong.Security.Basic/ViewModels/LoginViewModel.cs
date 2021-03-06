﻿using System.ComponentModel.DataAnnotations;

namespace Bong.Security.Basic.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}