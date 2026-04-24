using Microsoft.EntityFrameworkCore;
using ProjetoPrincipal.Models;

namespace ProjetoPrincipal.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
