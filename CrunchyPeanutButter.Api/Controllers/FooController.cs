using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Collections;
using CrunchyPeanutButter.Domain.Commands.Foos;
using CrunchyPeanutButter.Domain.Models;
using CrunchyPeanutButter.Domain.Queries.Foos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("foos")]
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public Task<Foo> FindAsync(int id)
        {
            return _mediator.Send(new FindFooQuery(id));
        }

        [HttpGet]
        public Task<Page<Foo>> PageAsync(int pageIndex, int pageSize, string sortBy, SortDirection sortDirection)
        {
            return _mediator.Send(new PageFooQuery(pageIndex, pageSize, sortBy, sortDirection));
        }

        [HttpPost]
        public Task<Foo> CreateAsync(Foo foo)
        {
            return _mediator.Send(new CreateFooCommand(foo));
        }

        [HttpPut("{id}")]
        public Task<Foo> UpdateAsync(Foo foo)
        {
            return _mediator.Send(new UpdateFooCommand(foo));
        }

        [HttpDelete("{id}")]
        public Task<bool> DeleteAsync(int id)
        {
            return _mediator.Send(new DeleteFooCommand(id));
        }
    }
}