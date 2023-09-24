using db_cp.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace db_cp.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<EventsTypes> EventsTypes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<ButtonsEvents> ButtonsEvents { get; set; }
        public DbSet<ButtonsPosts> ButtonsPosts { get; set; }
        public DbSet<News> News { get; set; }
    }
}
