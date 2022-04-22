using ShopBridge.Services.Core.Enums;

namespace ShopBridge.Services.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public UserRole Role { get; set; }
    }
}
