using AutoMapper;
using GroceryStoreServices.Api.Book.Application.Dto;
using GroceryStoreServices.Api.Book.Model;

namespace GroceryStoreServices.Api.Book.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Library, LibraryDto>();
        }
    }
}
