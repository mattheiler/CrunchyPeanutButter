using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Api.Models.Bars;
using CrunchyPeanutButter.Domain.Bars.Commands;
using CrunchyPeanutButter.Queries.Bars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("bars")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        private readonly IBarQueries _queries;

        public BarController(IMediator mediator, IBarQueries queries, IMapper mapper)
        {
            _mediator = mediator;
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet("{id:long}")]
        public async Task<BarFindResponse> FindAsync([FromRoute] long id)
        {
            return _mapper.Map<BarFindResponse>(await _queries.FindAsync(id));
        }

        [HttpGet]
        public async Task<BarPageResponse> PageAsync([FromQuery] BarPageRequest request)
        {
            return _mapper.Map<BarPageResponse>(await _queries.PageAsync(request.SortBy, request.SortDirection, request.PageIndex, request.PageSize));
        }

        [HttpPost]
        public async Task<BarCreateResponse> CreateAsync([FromBody] BarCreateRequest request)
        {
            return _mapper.Map<BarCreateResponse>(await _mediator.Send(_mapper.Map<CreateBarCommand>(request)));
        }

        [HttpPut("{id:long}")]
        public async Task<BarUpdateResponse> UpdateAsync([FromBody] BarUpdateRequest request)
        {
            return _mapper.Map<BarUpdateResponse>(await _mediator.Send(_mapper.Map<UpdateBarCommand>(request)));
        }

        [HttpDelete("{id:long}")]
        public async Task<BarDeleteResponse> DeleteAsync([FromRoute] BarDeleteRequest request)
        {
            return _mapper.Map<BarDeleteResponse>(await _mediator.Send(_mapper.Map<DeleteBarCommand>(request)));
        }
    }
}