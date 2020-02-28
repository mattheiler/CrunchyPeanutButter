using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Data.Paging;
using CrunchyPeanutButter.Domain.Collections;
using CrunchyPeanutButter.Domain.Models;
using CrunchyPeanutButter.Domain.Queries.Foos;
using MediatR;

namespace CrunchyPeanutButter.Data.QueryHandlers.Foos
{
    public class PageFooQueryHandler : IRequestHandler<PageFooQuery, Page<Foo>>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public PageFooQueryHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public Task<Page<Foo>> Handle(PageFooQuery request, CancellationToken cancellationToken)
        {
            return _context.Foos.SortBy(request.SortBy, request.SortDirection).ToPageAsync(request.Index, request.Size);
        }
    }
}