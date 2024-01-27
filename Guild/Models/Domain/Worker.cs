namespace Guild.Models.Domain
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone {  get; set; }
        public string Password { get; set; }

        public string? Address { get; set; }

    }
}
