using CrispyBacon.Data.EntityFrameworkCore;
using CrunchyPeanutButter.Data.Stores;
using CrunchyPeanutButter.Domain.Stores;

namespace CrunchyPeanutButter.Data
{
    public class CrunchyPeanutButterDbContextUnitOfWork : DbContextUnitOfWork<CrunchyPeanutButterDbContext>, ICrunchyPeanutButterUnitOfWork
    {
        public CrunchyPeanutButterDbContextUnitOfWork(CrunchyPeanutButterDbContext context) : base(context)
        {
        }


        public IBarRepository Bars => (IBarRepository)GetRepository(() => new BarRepository(Context.Bars));

        public IFooRepository Foos => (IFooRepository)GetRepository(() => new FooRepository(Context.Foos));
    }
}