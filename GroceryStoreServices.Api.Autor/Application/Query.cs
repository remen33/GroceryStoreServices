using AutoMapper;
using GroceryStoreServices.Api.Autor.Application.DTOs;
using GroceryStoreServices.Api.Autor.Model;
using GroceryStoreServices.Api.Autor.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Autor.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorDto>> { }

        public class Handler : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            private readonly AuthorContext _authorContext;
            private readonly IMapper _mapper;

            public Handler(AuthorContext authorContext, IMapper mapper)
            {
                this._authorContext = authorContext;
                _mapper = mapper;
            }
            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var result = await _authorContext.AuthorBook.ToListAsync();

                return _mapper.Map<List<AuthorDto>>(result);
            }
        }
    }
}
