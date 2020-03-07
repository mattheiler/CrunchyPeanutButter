using CrispyBacon.Data.EntityFrameworkCore;
using CrunchyPeanutButter.Data.Stores;
using CrunchyPeanutButter.Domain;
using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Bars.Stores;
using CrunchyPeanutButter.Domain.Foos;
using CrunchyPeanutButter.Domain.Foos.Stores;

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