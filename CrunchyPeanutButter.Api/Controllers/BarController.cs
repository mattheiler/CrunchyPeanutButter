using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Commands.Bars;
using CrunchyPeanutButter.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("bars")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Bar> CreateAsync(Bar bar)
        {
            return await _mediator.Send(new CreateBarCommand(bar));
        }

        [HttpPut("{id}")]
        public async Task<Bar> UpdateAsync(Bar bar)
        {
            return await _mediator.Send(new UpdateBarCommand(bar));
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _mediator.Send(new DeleteBarCommand(id));
        }
    }
}