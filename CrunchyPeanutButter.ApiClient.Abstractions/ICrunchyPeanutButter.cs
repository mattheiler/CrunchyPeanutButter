using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyPeanutButter.ApiClient.Abstractions.Models;

namespace CrunchyPeanutButter.ApiClient.Abstractions
{
    public interface ICrunchyPeanutButter
    {
        Task<Bar> GetBarAsync(int id);

        Task<IReadOnlyCollection<Bar>> GetBarsAsync(int? pageIndex = default, int? pageSize = default);

        Task CreateBarAsync(Bar bar);

        Task UpdateBarAsync(int id, Bar bar);

        Task DeleteBarAsync(int id);

        Task<Foo> GetFooAsync(int id);

        Task<IReadOnlyCollection<Foo>> GetFoosAsync(int? pageIndex = default, int? pageSize = default);

        Task CreateFooAsync(Foo foo);

        Task UpdateFooAsync(int id, Foo foo);

        Task DeleteFooAsync(int id);
    }
}