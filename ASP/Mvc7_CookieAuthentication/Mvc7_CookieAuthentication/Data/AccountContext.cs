namespace Mvc7_CookieAuthentication.Data
{
    public class AccountContext : DbContext
    {
        private readonly IHashService _hashService;
        public AccountContext(DbContextOptions<AccountContext> options, IHashService hashService) : base(options)
        {
            _hashService = hashService;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Password未加密
            modelBuilder.Entity<User>().HasData(
                new User { Id = "U001", Name = "Kevin@gmail.com", Email = "kevinxi@gmail.com", Password = "12345", Nickname = "無敵霸主", PhoneNo = "0925-155222" },
                new User { Id = "U002", Name = "Mary@gmail.com", Email = "marylee@gmail.com", Password = "12345", Nickname = "飛天女俠", PhoneNo = "0935-123123" },
                new User { Id = "U003", Name = "John@gmail.com", Email = "johnwei@gmail.com", Password = "12345", Nickname = "小李飛刀", PhoneNo = "0955-456456" }
                );

            //Password以MD5加密
            //modelBuilder.Entity<User>().HasData(
            //    new User { Id = "U001", Name = "Kevin@gmail.com", Email = "kevinxi@gmail.com", Password = _hashService.MD5Hash("12345"), Nickname = "無敵霸主", PhoneNo = "0925-155222" },
            //    new User { Id = "U002", Name = "Mary@gmail.com", Email = "marylee@gmail.com", Password = _hashService.MD5Hash("12345"), Nickname = "飛天女俠", PhoneNo = "0935-123123" },
            //    new User { Id = "U003", Name = "John@gmail.com", Email = "johnwei@gmail.com", Password = _hashService.MD5Hash("12345"), Nickname = "小李飛刀", PhoneNo = "0955-456456" }
            //    );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = "R001", Name = "Administrator" },
                new Role { Id = "R002", Name = "Sales" },
                new Role { Id = "R003", Name = "RD" },
                new Role { Id = "R004", Name = "Operation" }
                );

            //使用了Entity Framework的Fluent API，通過使用HasKey方法將UserId和RoleId屬性標記為複合主鍵
            modelBuilder.Entity<UserRoles>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { UserId = "U001", RoleId = "R001" },
                new UserRoles { UserId = "U001", RoleId = "R003" },
                new UserRoles { UserId = "U002", RoleId = "R002" },
                new UserRoles { UserId = "U003", RoleId = "R003" },
                new UserRoles { UserId = "U003", RoleId = "R004" }
                );
        }
    }
}
