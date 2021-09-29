using AutoMapper;
using GroceryStoreServices.Api.Autor.Application.DTOs;
using GroceryStoreServices.Api.Autor.Model;

namespace GroceryStoreServices.Api.Autor.Application
{
    public class MappingProfile  : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorBook, AuthorDto>();
        }
    }
}
