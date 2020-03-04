using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Domain.Foos;

namespace CrunchyPeanutButter.Api.Queries
{
    public interface IFooQueries
    {
        Task<Foo> FindAsync(in int id);

        Task<Page<Foo>> PageAsync(in string sortBy, SortDirection sortDirection, in int pageIndex, in int pageSize);
    }
}