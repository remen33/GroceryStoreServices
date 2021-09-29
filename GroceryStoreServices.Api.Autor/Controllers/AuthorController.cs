using GroceryStoreServices.Api.Autor.Application;
using GroceryStoreServices.Api.Autor.Application.DTOs;
using GroceryStoreServices.Api.Autor.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data) 
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async  Task<ActionResult<List<AuthorDto>>> GetAuthors() 
        {
            return await _mediator.Send(new Query.AuthorList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorBook(string id)
        {
            return await _mediator.Send(new QueryFilter.UniqueAuthor{ AuthorGuid = id});
        }
    }
}
