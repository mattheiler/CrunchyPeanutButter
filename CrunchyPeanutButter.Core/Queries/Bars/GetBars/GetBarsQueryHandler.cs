using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Core.Abstractions.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Core
{
    public class GetBarsQueryHandler : IRequestHandler<GetBarsQuery, List<GetBarsQueryResult>>
    {
        private readonly IDbContext _context;

        private readonly IConfigurationProvider _mappings;

        public GetBarsQueryHandler(IDbContext context, IConfigurationProvider mappings)
        {
            _context = context;
            _mappings = mappings;
        }

        public Task<List<GetBarsQueryResult>> Handle(GetBarsQuery request, CancellationToken cancellationToken)
        {
            return
                _context
                    .Bars
                    .OrderBy(foo => foo.Id)
                    .Skip(request.Params.PageSize * request.Params.PageIndex)
                    .Take(request.Params.PageSize)
                    .ProjectTo<GetBarsQueryResult>(_mappings)
                    .ToListAsync(cancellationToken);
        }
    }
}