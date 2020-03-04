using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Api.Commands.Foos;
using CrunchyPeanutButter.Api.Queries;
using CrunchyPeanutButter.Domain.Foos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("foos")]
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IFooQueries _queries;

        public FooController(IMediator mediator, IFooQueries queries)
        {
            _mediator = mediator;
            _queries = queries;
        }

        [HttpGet("{id:int}")]
        public Task<Foo> FindAsync(int id)
        {
            return _queries.FindAsync(id);
        }

        [HttpGet]
        public Task<Page<Foo>> PageAsync(string sortBy, SortDirection sortDirection, int pageIndex, int pageSize)
        {
            return _queries.PageAsync(sortBy, sortDirection, pageIndex, pageSize);
        }

        [HttpPost]
        public Task<Foo> CreateAsync(CreateFooCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut("{id:int}")]
        public Task<Foo> UpdateAsync(UpdateFooCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{id:int}")]
        public Task<bool> DeleteAsync(DeleteFooCommand command)
        {
            return _mediator.Send(command);
        }
    }
}