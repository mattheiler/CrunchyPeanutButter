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
    public class GetBarQueryHandler : IRequestHandler<GetBarQuery, GetBarQueryResult>
    {
        private readonly IDbContext _context;

        private readonly IConfigurationProvider _mappings;

        public GetBarQueryHandler(IDbContext context, IConfigurationProvider mappings)
        {
            _context = context;
            _mappings = mappings;
        }

        public Task<GetBarQueryResult> Handle(GetBarQuery request, CancellationToken cancellationToken)
        {
            return
                _context
                    .Bars
                    .Select(bar => bar.Id == request.Id)
                    .ProjectTo<GetBarQueryResult>(_mappings)
                    .SingleOrDefaultAsync(cancellationToken);
        }
    }
}