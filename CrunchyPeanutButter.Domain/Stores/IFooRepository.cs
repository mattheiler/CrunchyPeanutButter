using CrispyBacon.Stores;
using CrunchyPeanutButter.Domain.Models.Foos;

namespace CrunchyPeanutButter.Domain.Stores
{
    public interface IFooRepository : IRepository<Foo>
    {
    }
}