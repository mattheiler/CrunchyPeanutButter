using System.Threading.Tasks;
using CrispyBacon.Collections;

namespace CrunchyPeanutButter.Queries.Bars
{
    public interface IBarQueries
    {
        Task<BarDetails> FindAsync(long id);

        Task<Page<BarHeader>> PageAsync(in string sortBy, SortDirection sortDirection, in int pageIndex, in int pageSize);
    }
}