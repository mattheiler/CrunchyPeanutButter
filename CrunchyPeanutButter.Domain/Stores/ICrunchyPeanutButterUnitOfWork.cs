using CrispyBacon.Data;

namespace CrunchyPeanutButter.Domain.Stores
{
    public interface ICrunchyPeanutButterUnitOfWork : IUnitOfWork
    {
        IBarRepository Bars { get; }

        IFooRepository Foos { get; }
    }
}