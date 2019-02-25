using System;
using System.Configuration;
using System.Data.Entity;

namespace ColorsViewer.DataAccess.Ef
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (connectionString != null)
            {
                Database.Connection.ConnectionString = connectionString.ConnectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            }
            
            Database.SetInitializer<ApplicationContext>(null);
        }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Item> Items { get; set; }

    }
}
