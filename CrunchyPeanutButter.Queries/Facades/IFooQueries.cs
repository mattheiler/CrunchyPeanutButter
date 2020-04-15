using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Queries.Models.Foos;

namespace CrunchyPeanutButter.Queries.Facades
{
    public interface IFooQueries
    {
        Task<FooDetails> FindAsync(long id);

        Task<Page<FooHeader>> PageAsync(in string sortBy, SortDirection sortDirection, in int pageIndex, in int pageSize);
    }
}