
namespace Mvc7_QuestionaryModelBinding.Data
{
    public class QuestionaryContext : DbContext
    {
        public QuestionaryContext(DbContextOptions<QuestionaryContext> options):base(options)
        {

        }

        public DbSet<Questionary> Questionary { get; set; }
    }
}
