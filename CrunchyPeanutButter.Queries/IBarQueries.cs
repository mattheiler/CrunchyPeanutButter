using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Domain.Bars;

namespace CrunchyPeanutButter.Queries
{
    public interface IBarQueries
    {
        Task<Bar> FindAsync(in long id);

        Task<Page<Bar>> PageAsync(in int pageIndex, in int pageSize, in int sortBy, SortDirection sortDirection);
    }
}