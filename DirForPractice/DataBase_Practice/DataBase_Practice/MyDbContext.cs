using System.Data.Entity;

namespace DataBase_Practice
{
    public class MyDbContext : DbContext // не рекомендуется делать контексты публичными
    {
        public MyDbContext() : base("DbConnectionString") { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
