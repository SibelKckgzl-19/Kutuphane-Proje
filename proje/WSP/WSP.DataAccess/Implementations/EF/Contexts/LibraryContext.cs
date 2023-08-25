using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSP.Model.Entities;

namespace WSP.DataAccess.Implementations.EF.Contexts
{
    public class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
              optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=Library1;trusted_connection=true;");

        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Publisher>? Publishers { get; set; }
        public DbSet<BType>? BTypes { get; set; }
            
    }
}
