using System;

namespace GroceryStoreServices.Api.Book.Model
{
    public class Library
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public Guid? AuthorBook { get; set; }
    }
}
