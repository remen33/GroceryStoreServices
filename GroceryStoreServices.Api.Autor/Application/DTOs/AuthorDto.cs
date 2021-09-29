using System;

namespace GroceryStoreServices.Api.Autor.Application.DTOs
{
    public class AuthorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public string AuthorBookGuid { get; set; }
    }
}
