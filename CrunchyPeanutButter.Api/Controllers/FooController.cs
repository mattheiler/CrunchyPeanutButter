using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Api.Models.Foos;
using CrunchyPeanutButter.Domain.Foos.Commands;
using CrunchyPeanutButter.Queries.Foos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("foos")]
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        private readonly IFooQueries _queries;

        public FooController(IMediator mediator, IFooQueries queries, IMapper mapper)
        {
            _mediator = mediator;
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet("{id:long}")]
        public async Task<FooFindResponse> FindAsync([FromRoute] long id)
        {
            return _mapper.Map<FooFindResponse>(await _queries.FindAsync(id));
        }

        [HttpGet]
        public async Task<FooPageResponse> PageAsync([FromQuery] FooPageRequest request)
        {
            return _mapper.Map<FooPageResponse>(await _queries.PageAsync(request.SortBy, request.SortDirection, request.PageIndex, request.PageSize));
        }

        [HttpPost]
        public async Task<FooCreateResponse> CreateAsync([FromBody] FooCreateRequest request)
        {
            return _mapper.Map<FooCreateResponse>(await _mediator.Send(_mapper.Map<CreateFooCommand>(request)));
        }

        [HttpPut("{id:long}")]
        public async Task<FooUpdateResponse> UpdateAsync([FromBody] FooUpdateRequest request)
        {
            return _mapper.Map<FooUpdateResponse>(await _mediator.Send(_mapper.Map<UpdateFooCommand>(request)));
        }

        [HttpDelete("{id:long}")]
        public async Task<FooDeleteResponse> DeleteAsync([FromRoute] FooDeleteRequest request)
        {
            return _mapper.Map<FooDeleteResponse>(await _mediator.Send(_mapper.Map<DeleteFooCommand>(request)));
        }
    }
}