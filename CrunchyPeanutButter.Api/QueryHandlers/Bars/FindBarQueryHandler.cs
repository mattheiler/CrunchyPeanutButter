using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Data;
using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Bars.Queries;
using MediatR;

namespace CrunchyPeanutButter.Api.QueryHandlers.Bars
{
    public class FindBarQueryHandler : IRequestHandler<FindBarQuery, Bar>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public FindBarQueryHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<Bar> Handle(FindBarQuery request, CancellationToken cancellationToken)
        {
            return await _context.Bars.FindAsync(request.Id);
        }
    }
}