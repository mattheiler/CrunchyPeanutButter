using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Models;
using CrunchyPeanutButter.Domain.Queries.Foos;
using MediatR;

namespace CrunchyPeanutButter.Data.QueryHandlers.Foos
{
    public class FindFooQueryHandler : IRequestHandler<FindFooQuery, Foo>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public FindFooQueryHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<Foo> Handle(FindFooQuery request, CancellationToken cancellationToken)
        {
            return await _context.Foos.FindAsync(request.Id);
        }
    }
}