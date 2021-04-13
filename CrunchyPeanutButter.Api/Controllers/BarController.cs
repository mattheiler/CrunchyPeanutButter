using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Commands.Bars.CreateBar;
using CrunchyPeanutButter.Application.Commands.Bars.DeleteBar;
using CrunchyPeanutButter.Application.Commands.Bars.UpdateBar;
using CrunchyPeanutButter.Application.Queries.Bars;
using CrunchyPeanutButter.Application.Queries.Bars.GetBar;
using CrunchyPeanutButter.Application.Queries.Bars.GetBars;
using CrunchyPeanutButter.Domain.Models.Bars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("bars")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly ISender _sender;

        public BarController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:int}")]
        public Task<BarViewModel> FindAsync(int id)
        {
            return _sender.Send(new GetBarQuery(id));
        }

        [HttpGet]
        public Task<List<BarViewModel>> PageAsync(int pageIndex, int pageSize)
        {
            return _sender.Send(new GetBarsQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            });
        }

        [HttpPost]
        public Task CreateAsync(Bar bar)
        {
            return _sender.Send(new CreateBarCommand(bar));
        }

        [HttpPut("{id:int}")]
        public Task UpdateAsync(int id, Bar bar)
        {
            return _sender.Send(new UpdateBarCommand(id, bar));
        }

        [HttpDelete("{id:int}")]
        public Task DeleteAsync(int id)
        {
            return _sender.Send(new DeleteBarCommand(id));
        }
    }
}