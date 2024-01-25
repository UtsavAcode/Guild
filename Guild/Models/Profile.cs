namespace Guild.Models
{
    public class Profile
    {

        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public string Occupation { get; set; }
        public string Password { get; set; }
    }
}
