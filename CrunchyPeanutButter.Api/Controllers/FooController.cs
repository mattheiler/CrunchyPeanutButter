using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Domain.Foos;
using CrunchyPeanutButter.Domain.Foos.Commands;
using CrunchyPeanutButter.Domain.Foos.Queries;
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
        public Task<Foo> FindAsync(FindFooQuery query)
        {
            return _mediator.Send(query);
        }

        [HttpGet]
        public Task<Page<Foo>> PageAsync(PageFooQuery query)
        {
            return _mediator.Send(query);
        }

        [HttpPost]
        public Task<Foo> CreateAsync(CreateFooCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public Task<Foo> UpdateAsync(UpdateFooCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public Task<bool> DeleteAsync(DeleteFooCommand command)
        {
            return _mediator.Send(command);
        }
    }
}