using Microsoft.Extensions.Options;

namespace EFCore_DbContextConfig.Models
{
    public class CardContext : DbContext
    {
        public CardContext()
        {

        }

        private readonly string _connString = null;
        public CardContext(string connString)
        {
            _connString = connString;
        }

        public CardContext(DbContextOptions<CardContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        //使用 'new' 的簡易 DbCoNtext 初始化 - https://learn.microsoft.com/zh-tw/ef/core/dbcontext-configuration/#simple-dbcontext-initialization-with-new

        //直接初始化DbContext需開啟這項
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var oBuilder = optionsBuilder;
            //string conn1 = this.Database.GetConnectionString();
            //string ccon2 = this.Database.GetDbConnection().ConnectionString;

            if (_connString==null)
            {
                //直接new CardContext()時未傳入資料庫連線字串
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CardSqlServerDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            else
            {
                //直接new CardContext()時傳入資料庫連線字串
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
                new Card { Id = 1, Name = "Elon Musk", Brief = "特斯拉創辦人 伊隆·馬斯克", Photo = "ElonMusk.jpg", WikiUrl = "https://goo.gl/46xeXx" },
                new Card { Id = 2, Name = "Mark Zuckerberg", Brief = "Facebook創辦人 馬克·祖伯克", Photo = "MarkZuckerberg.jpg", WikiUrl = "https://goo.gl/BktGGA" },
                new Card { Id = 3, Name = "Steve Jobs", Brief = "蘋果創辦人 史提夫·賈伯斯", Photo = "SteveJobs.jpg", WikiUrl = "https://goo.gl/nAiX0y" },
                new Card { Id = 4, Name = "Vader", Brief = "帝國元帥  維達", Photo = "Vader.jpg", WikiUrl = "https://en.wikipedia.org/wiki/Darth_Vader" },
                new Card { Id = 5, Name = "Darth Mual", Brief = "星際大戰 達斯摩", Photo = "DarthMual.jpg", WikiUrl = "https://goo.gl/5obLhX" },
                new Card { Id = 6, Name = "White Twilek", Brief = "星際大戰 女絕地武士Twilek", Photo = "WhiteTwilek.jpg", WikiUrl = "https://goo.gl/reKzAu" }
                );
        }
    }

}
