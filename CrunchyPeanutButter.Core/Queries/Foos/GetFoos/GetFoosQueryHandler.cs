using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Core.Abstractions;
using CrunchyPeanutButter.Core.Collections;
using CrunchyPeanutButter.Core.Extensions;
using MediatR;

namespace CrunchyPeanutButter.Core.Queries.Foos.GetFoos
{
    public class GetFoosQueryHandler : IRequestHandler<GetFoosQuery, Page<GetFoosQueryResult>>
    {
        private readonly IDbContext _context;
        private readonly IConfigurationProvider _mapping;

        public GetFoosQueryHandler(IDbContext context, IConfigurationProvider mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<Page<GetFoosQueryResult>> Handle(GetFoosQuery request, CancellationToken cancellationToken)
        {
            var results =
                await _context
                    .Foos
                    .OrderBy(foo => foo.Id)
                    .ProjectTo<GetFoosQueryResult>(_mapping)
                    .ToPageAsync(request.Offset, request.Limit, cancellationToken);
            return results;
        }
    }
}