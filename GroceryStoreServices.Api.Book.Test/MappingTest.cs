using AutoMapper;
using GroceryStoreServices.Api.Book.Application.Dto;
using GroceryStoreServices.Api.Book.Model;

namespace GroceryStoreServices.Api.Book.Test
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Library, LibraryDto>();
        }
    }
}
