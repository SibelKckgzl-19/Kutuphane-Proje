using Microsoft.EntityFrameworkCore;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.DataAccess.Implementations.EF.Contexts
{
    public class LibraryContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=Librarys;trusted_connection=true;");
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<AdminPanelUser>? AdminPanelUsers { get; set; }
    }
}
