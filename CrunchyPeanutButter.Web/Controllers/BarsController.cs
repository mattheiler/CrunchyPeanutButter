using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyPeanutButter.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Controllers
{
    [Route("bars")]
    [ApiController]
    public class BarsController : ControllerBase
    {
        private readonly ISender _sender;

        public BarsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:int}")]
        public Task<GetBarQueryResult> GetBarAsync(int id)
        {
            return _sender.Send(new GetBarQuery(id));
        }

        [HttpGet]
        public Task<List<GetBarsQueryResult>> GetBarsAsync([FromQuery] GetBarsQueryParams @params)
        {
            return _sender.Send(new GetBarsQuery(@params));
        }

        [HttpPost]
        public Task CreateBarAsync(CreateBarCommandArgs args)
        {
            return _sender.Send(new CreateBarCommand(args));
        }

        [HttpPut("{id:int}")]
        public Task UpdateBarAsync(int id, UpdateBarCommandArgs args)
        {
            return _sender.Send(new UpdateBarCommand(id, args));
        }

        [HttpDelete("{id:int}")]
        public Task DeleteBarAsync(int id)
        {
            return _sender.Send(new DeleteBarCommand(id));
        }
    }
}