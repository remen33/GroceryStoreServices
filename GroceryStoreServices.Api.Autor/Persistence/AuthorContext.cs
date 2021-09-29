using GroceryStoreServices.Api.Autor.Model;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreServices.Api.Autor.Persistence
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options ): base(options) { }

        public DbSet<AuthorBook> AuthorBook { get; set; }

        public DbSet<DegreeLevel> DegreeLevel { get; set; }
    }
}
