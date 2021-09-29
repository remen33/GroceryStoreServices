using GroceryStoreServices.Api.Book.Model;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreServices.Api.Book.Persistence
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() {  }
        public LibraryContext(DbContextOptions<LibraryContext> options): base(options) { }

        public virtual DbSet<Library> Library { get; set; }
    }
}
