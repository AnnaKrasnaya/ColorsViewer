using System.Data.Entity;

namespace ColorsViewer.DataAccess.Ef
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionString) : base("DefaultConnection")
        {
            Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer<ApplicationContext>(null);
        }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}
