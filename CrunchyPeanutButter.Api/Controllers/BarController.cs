using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Collections;
using CrunchyPeanutButter.Domain.Commands.Bars;
using CrunchyPeanutButter.Domain.Models;
using CrunchyPeanutButter.Domain.Queries.Bars;
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
        public Task<Bar> FindAsync(int id)
        {
            return _mediator.Send(new FindBarQuery(id));
        }

        [HttpGet]
        public Task<Page<Bar>> PageAsync(int pageIndex, int pageSize, string sortBy, SortDirection sortDirection)
        {
            return _mediator.Send(new PageBarQuery(pageIndex, pageSize, sortBy, sortDirection));
        }

        [HttpPost]
        public Task<Bar> CreateAsync(Bar bar)
        {
            return _mediator.Send(new CreateBarCommand(bar));
        }

        [HttpPut("{id}")]
        public Task<Bar> UpdateAsync(Bar bar)
        {
            return _mediator.Send(new UpdateBarCommand(bar));
        }

        [HttpDelete("{id}")]
        public Task<bool> DeleteAsync(int id)
        {
            return _mediator.Send(new DeleteBarCommand(id));
        }
    }
}