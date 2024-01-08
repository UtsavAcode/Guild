﻿using System.ComponentModel.DataAnnotations;

namespace Guild.Models
{
    public class Login
    {
        [Required (ErrorMessage ="Email is required.")]
        public string UserEmail { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The password must be at least 6 characters.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$", ErrorMessage = "Password must contain at least one number and a symbol.")]
        public string UserPassword { get; set; }

    }
}