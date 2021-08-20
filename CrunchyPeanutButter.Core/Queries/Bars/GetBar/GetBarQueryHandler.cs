using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Core.Queries.Bars.GetBar
{
    public class GetBarQueryHandler : IRequestHandler<GetBarQuery, GetBarQueryResult>
    {
        private readonly ICrunchyPeanutButterDbContext _context;
        private readonly IConfigurationProvider _mapping;

        public GetBarQueryHandler(ICrunchyPeanutButterDbContext context, IConfigurationProvider mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<GetBarQueryResult> Handle(GetBarQuery request, CancellationToken cancellationToken)
        {
            var results =
                await _context
                    .Bars
                    .Where(foo => foo.Id == request.Id)
                    .ProjectTo<GetBarQueryResult>(_mapping)
                    .SingleAsync(cancellationToken);
            return results;
        }
    }
}