using FluentValidation;
using GroceryStoreServices.Api.Autor.Model;
using GroceryStoreServices.Api.Autor.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Autor.Application
{
    public class New
    {
        public class Handler : IRequestHandler<Execute>
        {
            public readonly AuthorContext _context;

            public Handler(AuthorContext authorContext)
            {
                _context = authorContext;
            } 
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var authorBook = new AuthorBook {
                    FirstName = request.FirstName,
                    BirthDate = request.BirthDate,
                    LastName = request.LastName,
                    AuthorBookGuid = Guid.NewGuid().ToString()
                };

                _context.AuthorBook.Add(authorBook);

                if (await _context.SaveChangesAsync() > 0)
                    return Unit.Value;

                throw new Exception("It was no possible to create new Author");
            }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(q => q.FirstName).NotEmpty();
                RuleFor(q => q.LastName).NotEmpty();
            }
        }

        public class Execute : IRequest
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public DateTime? BirthDate { get; set; }            
        }
    }
}
