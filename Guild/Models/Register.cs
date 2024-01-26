﻿using System.ComponentModel.DataAnnotations;

namespace Guild.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }

      
      
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }
       
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
