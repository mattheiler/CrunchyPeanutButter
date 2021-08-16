using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Bars.CreateBar;
using CrunchyPeanutButter.Core.Bars.DeleteBar;
using CrunchyPeanutButter.Core.Bars.UpdateBar;
using CrunchyPeanutButter.Core.GetFoo;
using CrunchyPeanutButter.Core.GetFoos;
using CrunchyPeanutButter.Web.Models.Foos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Controllers
{
    //[Authorize]
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
        public async Task CreateFoo(CreateFooRequest request)
        {
            var command = _mapper.Map<CreateBarCommand>(request);
            await _sender.Send(command);
        }

        [HttpPut("{id}")]
        public async Task UpdateFoo(UpdateFooRequest request)
        {
            var command = _mapper.Map<UpdateBarCommand>(request);
            await _sender.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteFoo(DeleteFooRequest request)
        {
            var command = _mapper.Map<DeleteBarCommand>(request);
            await _sender.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<GetFooResponse> GetFoo(CreateFooRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetFooQuery>(request);
            var result = await _sender.Send(query, cancellationToken);
            var response = _mapper.Map<GetFooResponse>(result);
            return response;
        }

        [HttpGet]
        public async Task<GetFoosResponse[]> GetFoos(GetFoosRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetFoosQuery>(request);
            var results = await _sender.Send(query, cancellationToken);
            Response.Headers.Add("X-Total-Count", results.Count.ToString());
            var response = results.Items.Select(_mapper.Map<GetFoosResponse>).ToArray();
            return response;
        }
    }
}