using System;
using System.Collections.Generic;

namespace GroceryStoreServices.Api.Autor.Model
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public ICollection<DegreeLevel> DegreeLevelList { get; set; }

        public string AuthorBookGuid { get; set; }
    }
}
