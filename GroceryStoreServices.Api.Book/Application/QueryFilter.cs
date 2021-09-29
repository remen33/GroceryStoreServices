using AutoMapper;
using GroceryStoreServices.Api.Book.Application.Dto;
using GroceryStoreServices.Api.Book.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Book.Application
{
    public class QueryFilter
    {
        public class UniqueLibrary: IRequest<LibraryDto>
        {
            public Guid? BookId { get; set; }
        }

        public class Handler : IRequestHandler<UniqueLibrary, LibraryDto>
        {
            private readonly LibraryContext _libraryContext;
            private readonly IMapper _mapper;

            public Handler(LibraryContext libraryContext, IMapper mapper)
            {
                _libraryContext = libraryContext;
                _mapper = mapper;
            }

            public async Task<LibraryDto> Handle(UniqueLibrary request, CancellationToken cancellationToken)
            {
                var result = await _libraryContext.Library.FirstOrDefaultAsync(q => q.Id.Equals(request.BookId));

                if (result == null)
                    throw new System.Exception("Author not found!!");

                return _mapper.Map<LibraryDto>(result);
            }
        }
    }
}
