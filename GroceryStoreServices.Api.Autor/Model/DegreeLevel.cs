using System;

namespace GroceryStoreServices.Api.Autor.Model
{
    public class DegreeLevel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string College { get; set; }

        public DateTime DegreeDate { get; set; }

        public int AuthorBookId { get; set; }

        public AuthorBook AuthorBook { get; set; }

        public string DegreeLevelGuid { get; set; }
    }
}
