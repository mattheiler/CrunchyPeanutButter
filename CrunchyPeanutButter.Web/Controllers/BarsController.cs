using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Bars.CreateBar;
using CrunchyPeanutButter.Core.Bars.DeleteBar;
using CrunchyPeanutButter.Core.Bars.UpdateBar;
using CrunchyPeanutButter.Core.GetBar;
using CrunchyPeanutButter.Core.GetBars;
using CrunchyPeanutButter.Web.Models.Bars;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Controllers
{
    [Authorize]
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
        public async Task CreateBar(CreateBarRequest request)
        {
            var command = _mapper.Map<CreateBarCommand>(request);
            await _sender.Send(command);
        }

        [HttpPut("{id}")]
        public async Task UpdateBar(UpdateBarRequest request)
        {
            var command = _mapper.Map<UpdateBarCommand>(request);
            await _sender.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteBar([FromRoute] DeleteBarRequest request)
        {
            var command = _mapper.Map<DeleteBarCommand>(request);
            await _sender.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<GetBarResponse> GetBar([FromQuery] GetBarRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetBarQuery>(request);
            var result = await _sender.Send(query, cancellationToken);
            var response = _mapper.Map<GetBarResponse>(result);
            return response;
        }

        [HttpGet]
        public async Task<GetBarsResponse[]> GetBars([FromQuery] GetBarsRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetBarsQuery>(request);
            var results = await _sender.Send(query, cancellationToken);
            Response.Headers.Add("X-Total-Count", results.Count.ToString());
            var response = results.Items.Select(_mapper.Map<GetBarsResponse>).ToArray();
            return response;
        }
    }
}