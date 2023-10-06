﻿using System.ComponentModel.DataAnnotations;

namespace IdentityServer.API.Dtos
{
    public class SignupDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string City { get; set; }

    }
}
