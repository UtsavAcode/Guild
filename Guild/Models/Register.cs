using System.ComponentModel.DataAnnotations;

namespace Guild.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }

      
      
     
        public string FirstName { get; set; }

   
        public string LastName { get; set; }

   
        public string Email { get; set; }

   
        public int Age { get; set; }
       
       
        public string Phone { get; set; }

    
        public string Password { get; set; }

        
    
    }
}
