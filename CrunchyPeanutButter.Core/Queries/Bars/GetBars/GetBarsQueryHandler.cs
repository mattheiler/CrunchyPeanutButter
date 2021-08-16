using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Core.Abstractions;
using CrunchyPeanutButter.Core.Collections;
using CrunchyPeanutButter.Core.Extensions;
using MediatR;

namespace CrunchyPeanutButter.Core.GetBars
{
    public class GetBarsQueryHandler : IRequestHandler<GetBarsQuery, Page<GetBarsQueryResult>>
    {
        private readonly IDbContext _context;
        private readonly IConfigurationProvider _mapping;

        public GetBarsQueryHandler(IDbContext context, IConfigurationProvider mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<Page<GetBarsQueryResult>> Handle(GetBarsQuery request, CancellationToken cancellationToken)
        {
            var results =
                await _context
                    .Foos
                    .OrderBy(foo => foo.Id)
                    .ProjectTo<GetBarsQueryResult>(_mapping)
                    .ToPageAsync(request.Offset, request.Limit, cancellationToken);
            return results;
        }
    }
}