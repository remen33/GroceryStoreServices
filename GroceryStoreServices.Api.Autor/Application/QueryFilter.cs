using AutoMapper;
using GroceryStoreServices.Api.Autor.Application.DTOs;
using GroceryStoreServices.Api.Autor.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Autor.Application
{
    public class QueryFilter
    {
        public class UniqueAuthor: IRequest<AuthorDto>
        {
            public string AuthorGuid { get; set; }
        }

        public class Handler : IRequestHandler<UniqueAuthor, AuthorDto>
        {
            private readonly AuthorContext _authorContext;
            private readonly IMapper _mapper;

            public Handler(AuthorContext authorContext, IMapper mapper)
            {
                _authorContext = authorContext;
                _mapper = mapper;
            }

            public async Task<AuthorDto> Handle(UniqueAuthor request, CancellationToken cancellationToken)
            {
                var result = await _authorContext.AuthorBook.FirstOrDefaultAsync(q => q.AuthorBookGuid.Equals(request.AuthorGuid));

                if (result == null)
                    throw new System.Exception("Author not found!!");

                return _mapper.Map<AuthorDto>(result);
            }
        }
    }
}
