namespace Mvc7_CookieAuthentication.Models
{
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }

        // Navigation property for UserRoles
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
