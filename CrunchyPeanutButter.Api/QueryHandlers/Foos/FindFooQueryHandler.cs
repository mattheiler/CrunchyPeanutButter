using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Data;
using CrunchyPeanutButter.Domain.Foos;
using CrunchyPeanutButter.Domain.Foos.Queries;
using MediatR;

namespace CrunchyPeanutButter.Api.QueryHandlers.Foos
{
    public class FindFooQueryHandler : IRequestHandler<FindFooQuery, Foo>
    {
        private readonly IUnitOfWork _context;

        public FindFooQueryHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Foo> Handle(FindFooQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetRepository<Foo>().FindAsync(request.Id);
        }
    }
}