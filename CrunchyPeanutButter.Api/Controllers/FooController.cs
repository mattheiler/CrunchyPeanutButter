using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Commands.Foos.CreateFoo;
using CrunchyPeanutButter.Application.Commands.Foos.DeleteFoo;
using CrunchyPeanutButter.Application.Commands.Foos.UpdateFoo;
using CrunchyPeanutButter.Application.Queries.Foos;
using CrunchyPeanutButter.Application.Queries.Foos.GetFoo;
using CrunchyPeanutButter.Application.Queries.Foos.GetFoos;
using CrunchyPeanutButter.Domain.Models.Foos;
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
        public Task<FooViewModel> GetFooAsync(int id)
        {
            return _sender.Send(new GetFooQuery(id));
        }

        [HttpGet]
        public Task<List<FooViewModel>> GetFoosAsync(int pageIndex = 0, int pageSize = 20)
        {
            return _sender.Send(new GetFoosQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            });
        }

        [HttpPost]
        public Task CreateAsync(Foo foo)
        {
            return _sender.Send(new CreateFooCommand(foo));
        }

        [HttpPut("{id:int}")]
        public Task UpdateAsync(int id, Foo foo)
        {
            return _sender.Send(new UpdateFooCommand(id, foo));
        }

        [HttpDelete("{id:int}")]
        public Task DeleteAsync(int id)
        {
            return _sender.Send(new DeleteFooCommand(id));
        }
    }
}