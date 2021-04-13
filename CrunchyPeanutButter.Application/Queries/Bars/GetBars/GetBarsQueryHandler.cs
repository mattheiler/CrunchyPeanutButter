using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Application.Queries.Bars.GetBars
{
    public class GetBarsQueryHandler : IRequestHandler<GetBarsQuery, List<BarViewModel>>
    {
        private readonly IDbContext _context;

        private readonly IConfigurationProvider _mappings;

        public GetBarsQueryHandler(IDbContext context, IConfigurationProvider mappings)
        {
            _context = context;
            _mappings = mappings;
        }

        public Task<List<BarViewModel>> Handle(GetBarsQuery request, CancellationToken cancellationToken)
        {
            return
                _context
                    .Foos
                    .OrderBy(foo => foo.Id)
                    .Skip(request.PageSize * request.PageIndex)
                    .Take(request.PageSize)
                    .ProjectTo<BarViewModel>(_mappings)
                    .ToListAsync(cancellationToken);
        }
    }
}