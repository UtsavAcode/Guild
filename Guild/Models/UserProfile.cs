using Guild.Models.Domain;

namespace Guild.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string Address {  get; set; }


        public int Id {  get; set; }
        public Worker Worker { get; set; }
    }
}
