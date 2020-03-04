using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Domain.Bars;

namespace CrunchyPeanutButter.Api.Queries
{
    public interface IBarQueries
    {
        Task<Bar> FindAsync(in int id);

        Task<Page<Bar>> PageAsync(in string sortBy, SortDirection sortDirection, in int pageIndex, in int pageSize);
    }
}