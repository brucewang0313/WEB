using Microsoft.EntityFrameworkCore;

public class Mvc10_FriendContext(DbContextOptions<Mvc10_FriendContext> options) : DbContext(options)
{
    public DbSet<Mvc10_Pillars.Models.Friend> Friend { get; set; } = default!;
}
