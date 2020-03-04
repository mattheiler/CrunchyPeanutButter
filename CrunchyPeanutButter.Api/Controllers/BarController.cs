using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Api.Commands.Bars;
using CrunchyPeanutButter.Api.Queries;
using CrunchyPeanutButter.Domain.Bars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("bars")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IBarQueries _queries;

        public BarController(IMediator mediator, IBarQueries queries)
        {
            _mediator = mediator;
            _queries = queries;
        }

        [HttpGet("{id:int}")]
        public Task<Bar> FindAsync(int id)
        {
            return _queries.FindAsync(id);
        }

        [HttpGet]
        public Task<Page<Bar>> PageAsync(string sortBy, SortDirection sortDirection, int pageIndex, int pageSize)
        {
            return _queries.PageAsync(sortBy, sortDirection, pageIndex, pageSize);
        }

        [HttpPost]
        public Task<Bar> CreateAsync(CreateBarCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut("{id:int}")]
        public Task<Bar> UpdateAsync(UpdateBarCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{id:int}")]
        public Task<bool> DeleteAsync(DeleteBarCommand command)
        {
            return _mediator.Send(command);
        }
    }
}