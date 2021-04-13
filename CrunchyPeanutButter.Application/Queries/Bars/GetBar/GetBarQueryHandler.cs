using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Application.Abstractions.Stores;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Application.Queries.Bars.GetBar
{
    public class GetBarQueryHandler : IRequestHandler<GetBarQuery, BarViewModel>
    {
        private readonly IDbContext _context;

        private readonly IConfigurationProvider _mappings;

        public GetBarQueryHandler(IDbContext context, IConfigurationProvider mappings)
        {
            _context = context;
            _mappings = mappings;
        }

        public Task<BarViewModel> Handle(GetBarQuery request, CancellationToken cancellationToken)
        {
            return
                _context
                    .Bars
                    .Select(bar => bar.Id == request.Id)
                    .ProjectTo<BarViewModel>(_mappings)
                    .SingleOrDefaultAsync(cancellationToken);
        }
    }
}