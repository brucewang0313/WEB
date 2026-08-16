namespace Mvc10_CookieAuthentication.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }

        // Navigation property for UserRoles
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
