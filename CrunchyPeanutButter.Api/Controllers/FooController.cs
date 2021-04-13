using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Commands.Foos;
using CrunchyPeanutButter.Application.Queries.Foos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("foos")]
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly ISender _sender;

        public FooController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:int}")]
        public Task<GetFooQueryResult> GetFooAsync(int id)
        {
            return _sender.Send(new GetFooQuery(id));
        }

        [HttpGet]
        public Task<List<GetFoosQueryResult>> GetFoosAsync(int pageIndex = 0, int pageSize = 20)
        {
            return _sender.Send(new GetFoosQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            });
        }

        [HttpPost]
        public Task CreateAsync(CreateFooCommandArgs args)
        {
            return _sender.Send(new CreateFooCommand(args));
        }

        [HttpPut("{id:int}")]
        public Task UpdateAsync(int id, UpdateFooCommandArgs args)
        {
            return _sender.Send(new UpdateFooCommand(id, args));
        }

        [HttpDelete("{id:int}")]
        public Task DeleteAsync(int id)
        {
            return _sender.Send(new DeleteFooCommand(id));
        }
    }
}