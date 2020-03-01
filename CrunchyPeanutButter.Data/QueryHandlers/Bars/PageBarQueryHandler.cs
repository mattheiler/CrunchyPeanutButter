using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrispyBacon.Data;
using CrispyBacon.Data.EntityFrameworkCore.Collections;
using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Bars.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data.QueryHandlers.Bars
{
    public class PageBarQueryHandler : IRequestHandler<PageBarQuery, Page<Bar>>
    {
        private readonly IUnitOfWork _context;

        public PageBarQueryHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public Task<Page<Bar>> Handle(PageBarQuery request, CancellationToken cancellationToken)
        {
            return _context
                .GetRepository<Bar>()
                .AsNoTracking()
                .SortBy(request.SortBy, request.SortDirection)
                .ToPageAsync(request.Index, request.Size);
        }
    }
}