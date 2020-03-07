using System.Linq;
using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrispyBacon.Data.EntityFrameworkCore.Collections;
using CrunchyPeanutButter.Queries.Foos;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data.Queries
{
    public class FooQueries : IFooQueries
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public FooQueries(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public Task<FooDetails> FindAsync(long id)
        {
            return _context.Foos
                .Where(foo => foo.Id == id)
                .Select(foo => new FooDetails
                {
                    Id = foo.Id,
                    Name = foo.Name,
                    BarIds = foo.Bars.Select(foobar => foobar.BarId).ToArray()
                })
                .SingleOrDefaultAsync();
        }

        public Task<Page<FooHeader>> PageAsync(in string sortBy, SortDirection sortDirection, in int pageIndex, in int pageSize)
        {
            return _context.Foos
                .SortBy(sortBy, sortDirection)
                .ToPageAsync(pageIndex, pageSize, foo => new FooHeader
                {
                    Id = foo.Id,
                    Name = foo.Name
                });
        }
    }
}