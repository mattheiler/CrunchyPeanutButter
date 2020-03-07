using CrispyBacon.Data;
using CrunchyPeanutButter.Domain.Bars.Stores;
using CrunchyPeanutButter.Domain.Foos.Stores;

namespace CrunchyPeanutButter.Domain
{
    public interface ICrunchyPeanutButterUnitOfWork : IUnitOfWork
    {
        IBarRepository Bars { get; }

        IFooRepository Foos { get; }
    }
}