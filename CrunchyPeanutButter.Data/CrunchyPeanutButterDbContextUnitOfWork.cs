using CrispyBacon.Data.EntityFrameworkCore;
using CrunchyPeanutButter.Data.Stores;
using CrunchyPeanutButter.Domain.Aggregates.Bars;
using CrunchyPeanutButter.Domain.Aggregates.Foos;
using CrunchyPeanutButter.Domain.Stores;

namespace CrunchyPeanutButter.Data
{
    public class CrunchyPeanutButterDbContextUnitOfWork : DbContextUnitOfWork<CrunchyPeanutButterDbContext>, ICrunchyPeanutButterUnitOfWork
    {
        public CrunchyPeanutButterDbContextUnitOfWork(CrunchyPeanutButterDbContext context) : base(context)
        {
        }


        public IBarRepository Bars => GetRepository<IBarRepository, Bar>(() => new BarRepository(Context.Bars));

        public IFooRepository Foos => GetRepository<IFooRepository, Foo>(() => new FooRepository(Context.Foos));
    }
}