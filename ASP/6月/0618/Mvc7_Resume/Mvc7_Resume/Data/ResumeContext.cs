namespace Mvc7_Resume.Data
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
