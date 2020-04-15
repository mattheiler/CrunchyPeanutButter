using System;
using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Domain.Commands.Bars;
using CrunchyPeanutButter.Domain.Models.Bars;
using CrunchyPeanutButter.Queries.Facades;
using CrunchyPeanutButter.Queries.Models.Bars;
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

        [HttpGet("{id:long}")]
        public Task<BarDetails> FindAsync(long id)
        {
            return _queries.FindAsync(id);
        }

        [HttpGet]
        public Task<Page<BarHeader>> PageAsync(int pageIndex, int pageSize, string sortBy = nameof(Bar.Id), SortDirection sortDirection = default)
        {
            return _queries.PageAsync(sortBy, sortDirection, pageIndex, pageSize);
        }

        [HttpPost]
        public Task<Bar> CreateAsync(Bar bar)
        {
            return _mediator.Send(new CreateBarCommand(bar));
        }

        [HttpPut("{id:long}")]
        public Task<Bar> UpdateAsync(long id, Bar bar)
        {
            if (bar.Id != id) throw new InvalidOperationException("Route ID doesn't match the body ID.");
            return _mediator.Send(new UpdateBarCommand(bar));
        }

        [HttpDelete("{id:long}")]
        public async Task<bool> DeleteAsync(long id)
        {
            return await _mediator.Send(new DeleteBarCommand(id));
        }
    }
}