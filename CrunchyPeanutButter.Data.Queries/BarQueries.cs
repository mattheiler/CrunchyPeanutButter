using System.Linq;
using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrispyBacon.Data.EntityFrameworkCore.Collections;
using CrunchyPeanutButter.Queries.Bars;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data.Queries
{
    public class BarQueries : IBarQueries
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public BarQueries(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public Task<BarDetails> FindAsync(long id)
        {
            return _context.Bars
                .Where(bar => bar.Id == id)
                .Select(bar => new BarDetails
                {
                    Id = bar.Id,
                    Name = bar.Name
                })
                .SingleOrDefaultAsync();
        }

        public Task<Page<BarHeader>> PageAsync(in string sortBy, SortDirection sortDirection, in int pageIndex, in int pageSize)
        {
            return _context.Bars
                .SortBy(sortBy, sortDirection)
                .ToPageAsync(pageIndex, pageSize, bar => new BarHeader
                {
                    Id = bar.Id,
                    Name = bar.Name
                });
        }
    }
}