using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Foos;

namespace CrunchyPeanutButter.Queries
{
    public interface IFooQueries
    {
        Task<Foo> FindAsync(in long id);

        Task<Page<Foo>> PageAsync(in int pageIndex, in int pageSize, in int sortBy, SortDirection sortDirection);
    }
}