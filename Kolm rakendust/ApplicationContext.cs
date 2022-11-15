using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kolm_rakendust
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Loginandpass> Loginandpassw { get; set; } = null;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=loginandpassdb;Trusted_Connection=True;");
        }*/
        
        public DbSet<Loginandpass> Logins => Set<Loginandpass>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=loginandpasswo.db");
        }
    }
}
