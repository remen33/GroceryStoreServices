using AutoMapper;
using GroceryStoreServices.Api.Book.Application.Dto;
using GroceryStoreServices.Api.Book.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Book.Application
{
    public class Query
    {

        public class Execute : IRequest<List<LibraryDto>> { }

        public class Handler : IRequestHandler<Execute, List<LibraryDto>>
        {
            private readonly IMapper _mapper;
            private readonly LibraryContext _libraryContext;

            public Handler(IMapper mapper, LibraryContext libraryContext)
            {
                _mapper = mapper;
                _libraryContext = libraryContext;
            }

            public async Task<List<LibraryDto>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _libraryContext.Library.ToListAsync();

                return _mapper.Map<List<LibraryDto>>(books);
            }
        }
    }
}