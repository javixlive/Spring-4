namespace BollywoodHubAPI.Models.Entities
{
    public class Users
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }  
        public required string Password { get; set; }
    }
}
