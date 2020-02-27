using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Models;
using CrunchyPeanutButter.Domain.Queries.Bars;
using MediatR;

namespace CrunchyPeanutButter.Data.Queries.Bars
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