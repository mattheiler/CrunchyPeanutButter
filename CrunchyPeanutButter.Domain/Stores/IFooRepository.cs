using CrispyBacon.Data;
using CrunchyPeanutButter.Domain.Aggregates.Foos;

namespace CrunchyPeanutButter.Domain.Stores
{
    public interface IFooRepository : IRepository<Foo>
    {
    }
}