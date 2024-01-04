using Guild.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Guild.Models
{
    public class Register
    {

        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage ="Name must contain only letters.")]
        public string Name { get; set; }



        [Required (ErrorMessage ="Age is required.")]
        [Range(18, int.MaxValue, ErrorMessage = "Age must be 18 years or older.")]
        public int Age { get; set; }
        
     
        public string Email { get; set; }


        [Required (ErrorMessage ="Password is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage ="The password must be at least 6 characters.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$",ErrorMessage ="Password must contain at least one number and a symbol.")]
        public string Password { get; set; }

        
        [Required(ErrorMessage ="The phone number is required.")]
        [StringLength(10,MinimumLength = 10, ErrorMessage ="This phone number donot exist.")]
        //[PhoneNotExists(ErrorMessage="The phone number is already exists. Please use a new number.")]
        public int Phone { get; set; } 


    }


    
    
}
