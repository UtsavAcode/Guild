using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Guild.Models
{
    public class Register
    {

        public string Name { get; set; }

        
        public int Age { get; set; }
        
     
        public string Email { get; set; }
        
   
        public string Password { get; set; } 
        
     
        public int Phone { get; set; } 


    }

    
}
