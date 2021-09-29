using FluentValidation;
using GroceryStoreServices.Api.Book.Model;
using GroceryStoreServices.Api.Book.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Book.Application
{
    public class New 
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public Guid? AuthorBook { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(q => q.Title).NotEmpty();
                RuleFor(q => q.ReleaseDate).NotEmpty();
                RuleFor(q => q.AuthorBook).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly LibraryContext _libraryContext;

            public Handler(LibraryContext libraryContext)
            {
                _libraryContext = libraryContext;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new Library
                {
                    Title = request.Title,
                    ReleaseDate = request.ReleaseDate,
                    AuthorBook = request.AuthorBook
                };


                _libraryContext.Library.Add(book);
                var result = await _libraryContext.SaveChangesAsync();

                if (result == 0)
                    throw new Exception("There is a error creating Book");

                return Unit.Value;
            }
        }
    }
}