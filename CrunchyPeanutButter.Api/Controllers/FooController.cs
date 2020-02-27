using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Commands.Foos;
using CrunchyPeanutButter.Domain.Models;
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

        [HttpPost]
        public async Task<Foo> CreateAsync(Foo foo)
        {
            return await _mediator.Send(new CreateFooCommand(foo));
        }

        [HttpPut("{id}")]
        public async Task<Foo> UpdateAsync(Foo foo)
        {
            return await _mediator.Send(new UpdateFooCommand(foo));
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _mediator.Send(new DeleteFooCommand(id));
        }
    }
}