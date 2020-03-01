using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Bars.Commands;
using CrunchyPeanutButter.Domain.Bars.Queries;
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

        [HttpGet("{id}")]
        public Task<Bar> FindAsync(FindBarQuery query)
        {
            return _mediator.Send(query);
        }

        [HttpGet]
        public Task<Page<Bar>> PageAsync(PageBarQuery query)
        {
            return _mediator.Send(query);
        }

        [HttpPost]
        public Task<Bar> CreateAsync(CreateBarCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public Task<Bar> UpdateAsync(UpdateBarCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public Task<bool> DeleteAsync(DeleteBarCommand command)
        {
            return _mediator.Send(command);
        }
    }
}