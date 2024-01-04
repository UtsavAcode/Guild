using Guild.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Guild.Models
{
    public class Register
    {
        [TwoWordName(ErrorMessage = "Name must consist of exactly two words.")]
        [RegularExpression(@"^[A-Za-z]+ [A-Za-z]+$", ErrorMessage ="Name must contain only letters.")]
        public string Name { get; set; }



        [Required (ErrorMessage ="Age is required.")]
        [Range(18, int.MaxValue, ErrorMessage = "Age must be 18 years or older.")]
        public int Age { get; set; }


        [UniqueEmail(ErrorMessage = "This email is already in use.")]
        public string Email { get; set; }


        [Required (ErrorMessage ="Password is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage ="The password must be at least 6 characters.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$",ErrorMessage ="Password must contain at least one number and a symbol.")]
        public string Password { get; set; }


        [UniquePhone(ErrorMessage =" ")]
        [Required(ErrorMessage ="The phone number is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid phone number. Use only digits.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This phone number does not exist.")]
        public string Phone { get; set; } 


    }


    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if(value == null || !(value is string ))
            {
                return new ValidationResult("The email is invalid.");
            }
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var email = value.ToString();

            var existingUser = context.Workers.FirstOrDefault(x => x.Email == email);

            if (existingUser != null)
            {
                return new ValidationResult("This email is already in use. Please use another email.");
            }
            return ValidationResult.Success;
        }
    }


    public class UniquePhoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            var context = (ApplicationDbContext) validationContext.GetService(typeof(ApplicationDbContext));
            var phone = value?.ToString();

            if (string.IsNullOrEmpty(phone))
            {
                // handling the case where the phone number is required.
                return new ValidationResult("The phone number is required.");
            }

            if(!Regex.IsMatch(phone, @"^[0-9]+$"))
            {
                //Handle the case where the phone number contains non-digit characcters
                return new ValidationResult("Invalid phone number. Use only digits.");
            }

            if (phone.Length != 10)
            {
                //Handle the case where the phone number lenght is not equal to 10.
                return new ValidationResult("This number doesnot exist.");
            }

            var existingUser = context.Workers.FirstOrDefault(x => x.Phone == phone);

            if (existingUser != null)
            {
                return new ValidationResult("This phone is already taken");
                }
            return ValidationResult.Success;
        }
    }
    
    // Validation of your name 

    public class TwoWordNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || !(value is string))
            {
                return new ValidationResult("Your name must contain letters.");
            }

            var name = value?.ToString();
            var words = name.Split(' ');

            if (words.Length != 2)
            {
                return new ValidationResult("Your name must consist of exactly two words.");
            }

            return ValidationResult.Success;
        }
    }



}
