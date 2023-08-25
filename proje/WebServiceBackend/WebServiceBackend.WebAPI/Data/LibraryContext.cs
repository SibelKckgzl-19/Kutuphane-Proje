using Microsoft.EntityFrameworkCore;
using WebServiceBackend.WebAPI.Model.Entities;

namespace WebServiceBackend.WebAPI.Data
{
    public class LibraryContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=Library;trusted_connection=true;");

        }
        public DbSet<Book>? Books { get; set; }
    }
}
