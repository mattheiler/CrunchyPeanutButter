using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Commands.Bars.CreateBar;
using CrunchyPeanutButter.Core.Commands.Bars.DeleteBar;
using CrunchyPeanutButter.Core.Commands.Bars.UpdateBar;
using CrunchyPeanutButter.Core.Queries.Bars.GetBar;
using CrunchyPeanutButter.Core.Queries.Bars.GetBars;
using CrunchyPeanutButter.Web.Models.Bars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Controllers
{
    // TODO enable auth
    // [Authorize]
    [ApiController]
    [Route("api/bars")]
    public class BarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public BarsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task CreateBar(BarRequest request)
        {
            await _sender.Send(new CreateBarCommand
            {
                Name = request.Name,
                Code = request.Code
            });
        }

        [HttpPut("{id:guid}")]
        public async Task UpdateBar(Guid id, BarRequest request)
        {
            await _sender.Send(new UpdateBarCommand
            {
                Id = id,
                Name = request.Name,
                Code = request.Code
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteBar(Guid id)
        {
            await _sender.Send(new DeleteBarCommand
            {
                Id = id
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<BarResponse> GetBar(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetBarQuery
            {
                Id = id
            };
            var result = await _sender.Send(query, cancellationToken);
            var response = _mapper.Map<BarResponse>(result);
            return response;
        }

        [HttpGet]
        public async Task<BarResponse[]> GetBars(int offset = 0, int limit = 20, CancellationToken cancellationToken = default)
        {
            var query = new GetBarsQuery
            {
                Offset = offset,
                Limit = limit
            };
            var results = await _sender.Send(query, cancellationToken);
            Response.Headers.Add("X-Total-Count", results.Count.ToString());
            var response = results.Items.Select(_mapper.Map<BarResponse>).ToArray();
            return response;
        }
    }
}