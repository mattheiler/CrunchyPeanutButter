using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrispyBacon.Data;
using CrispyBacon.Data.EntityFrameworkCore.Collections;
using CrunchyPeanutButter.Domain.Foos;
using CrunchyPeanutButter.Domain.Foos.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data.QueryHandlers.Foos
{
    public class PageFooQueryHandler : IRequestHandler<PageFooQuery, Page<Foo>>
    {
        private readonly IUnitOfWork _context;

        public PageFooQueryHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public Task<Page<Foo>> Handle(PageFooQuery request, CancellationToken cancellationToken)
        {
            return _context
                .GetRepository<Foo>()
                .AsNoTracking()
                .SortBy(request.SortBy, request.SortDirection)
                .ToPageAsync(request.Index, request.Size);
        }
    }
}