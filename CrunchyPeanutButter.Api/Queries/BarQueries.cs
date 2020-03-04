using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrispyBacon.Data;
using CrispyBacon.Data.EntityFrameworkCore.Collections;
using CrunchyPeanutButter.Domain.Bars;

namespace CrunchyPeanutButter.Api.Queries
{
    public class BarQueries: IBarQueries
    {
        private readonly IUnitOfWork _context;

        public BarQueries(IUnitOfWork context)
        {
            _context = context;
        }

        public Task<Bar> FindAsync(in int id)
        {
            return _context.GetRepository<Bar>().FindAsync(id);
        }

        public Task<Page<Bar>> PageAsync(in string sortBy, SortDirection sortDirection, in int pageIndex, in int pageSize)
        {
            return _context.GetRepository<Bar>().SortBy(sortBy, sortDirection).ToPageAsync(pageIndex, pageSize);
        }
    }
}