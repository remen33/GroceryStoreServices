using System;

namespace GroceryStoreServices.Api.Book.Application.Dto
{
    public class LibraryDto
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public Guid? AuthorBook { get; set; }
    }
}
