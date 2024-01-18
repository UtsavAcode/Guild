using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Guild.Models
{
    public class Update
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [TwoWordName(ErrorMessage = "Name must consist of exactly two words.")]
        [RegularExpression(@"^[A-Za-z]+ [A-Za-z]+$", ErrorMessage = "Name must contain only letters.")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Age is required.")]
        [Range(18, int.MaxValue, ErrorMessage = "Age must be 18 years or older.")]
        public int Age { get; set; }


        [UniqueEmail(ErrorMessage = "This email is already in use.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The password must be at least 6 characters.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$", ErrorMessage = "Password must contain at least one number and a symbol.")]
        public string Password { get; set; }


        [UniquePhone(ErrorMessage = " ")]
        [Required(ErrorMessage = "The phone number is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid phone number. Use only digits.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This phone number does not exist.")]
        public string Phone { get; set; }


    }
}
