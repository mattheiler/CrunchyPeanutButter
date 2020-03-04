using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrispyBacon.Data;
using CrispyBacon.Data.EntityFrameworkCore.Collections;
using CrunchyPeanutButter.Domain.Foos;

namespace CrunchyPeanutButter.Api.Queries
{
    public class FooQueries : IFooQueries
    {
        private readonly IUnitOfWork _context;

        public FooQueries(IUnitOfWork context)
        {
            _context = context;
        }

        public Task<Foo> FindAsync(in int id)
        {
            return _context.GetRepository<Foo>().FindAsync(id);
        }

        public Task<Page<Foo>> PageAsync(in string sortBy, SortDirection sortDirection, in int pageIndex, in int pageSize)
        {
            return _context.GetRepository<Foo>().SortBy(sortBy, sortDirection).ToPageAsync(pageIndex, pageSize);
        }
    }
}
