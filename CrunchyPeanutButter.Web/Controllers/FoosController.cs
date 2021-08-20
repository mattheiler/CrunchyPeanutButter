using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Commands.Foos.CreateFoo;
using CrunchyPeanutButter.Core.Commands.Foos.DeleteFoo;
using CrunchyPeanutButter.Core.Commands.Foos.UpdateFoo;
using CrunchyPeanutButter.Core.Queries.Foos.GetFoo;
using CrunchyPeanutButter.Core.Queries.Foos.GetFoos;
using CrunchyPeanutButter.Web.Models.Foos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Controllers
{
    // TODO enable auth
    // [Authorize]
    [ApiController]
    [Route("api/foos")]
    public class FoosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public FoosController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task CreateFoo(FooRequest request)
        {
            await _sender.Send(new CreateFooCommand
            {
                Name = request.Name,
                Code = request.Code
            });
        }

        [HttpPut("{id:guid}")]
        public async Task UpdateFoo(Guid id, FooRequest request)
        {
            await _sender.Send(new UpdateFooCommand
            {
                Id = id,
                Name = request.Name,
                Code = request.Code
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteFoo(Guid id)
        {
            await _sender.Send(new DeleteFooCommand
            {
                Id = id
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<FooResponse> GetFoo(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetFooQuery
            {
                Id = id
            };
            var result = await _sender.Send(query, cancellationToken);
            var response = _mapper.Map<FooResponse>(result);
            return response;
        }

        [HttpGet]
        public async Task<FooResponse[]> GetFoos(int offset = 0, int limit = 20, CancellationToken cancellationToken = default)
        {
            var query = new GetFoosQuery
            {
                Offset = offset,
                Limit = limit
            };
            var results = await _sender.Send(query, cancellationToken);
            Response.Headers.Add("X-Total-Count", results.Count.ToString());
            var response = results.Items.Select(_mapper.Map<FooResponse>).ToArray();
            return response;
        }
    }
}