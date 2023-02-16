﻿using System.ComponentModel.DataAnnotations;

namespace Repository.Dto
{
    public class UserRequest
    {
        [Required]
        public string UserName { get; set; } = "";

        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [StringLength(80, ErrorMessage = "Your password must be between {2} and {1} characters", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "";

        [Display(Name = "Country")]
        public string? Country { get; set; }

        [Display(Name = "Biography")]
        public string? Biography { get; set; }

        [Display(Name = "ELO")]
        public int ELO { get; set; }
    }
}
