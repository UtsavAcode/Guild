using Guild.Models.Domain;
using Microsoft.Build.ObjectModelRemoting;

namespace Guild.Models
{
    public class Profile
    {

        public int ProfileId { get; set; }

        public int WorkerId {  get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public virtual worker Worker { get; set; }
    }
}
