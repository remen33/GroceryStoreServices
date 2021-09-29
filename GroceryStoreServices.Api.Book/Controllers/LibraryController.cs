using GroceryStoreServices.Api.Book.Application;
using GroceryStoreServices.Api.Book.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IMediator  _mediator;

        public LibraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data) 
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibraryDto>>> GetBooks()
        {
           return await _mediator.Send(new Query.Execute());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryDto>> GetBookById(Guid id)
        {
            return await _mediator.Send(new QueryFilter.UniqueLibrary { BookId = id });
        }
    }
}
