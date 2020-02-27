using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Data.Paging;
using CrunchyPeanutButter.Domain.Collections;
using CrunchyPeanutButter.Domain.Models;
using CrunchyPeanutButter.Domain.Queries.Bars;
using MediatR;

namespace CrunchyPeanutButter.Data.Queries.Bars
{
    public class PageBarQueryHandler : IRequestHandler<PageBarQuery, Page<Bar>>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public PageBarQueryHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public Task<Page<Bar>> Handle(PageBarQuery request, CancellationToken cancellationToken)
        {
            return _context.Bars.SortBy(request.SortBy, request.SortDirection).ToPageAsync(request.Index, request.Size);
        }
    }
}