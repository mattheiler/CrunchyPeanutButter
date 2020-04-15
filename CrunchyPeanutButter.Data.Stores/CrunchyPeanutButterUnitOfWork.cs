using CrispyBacon.Stores.EntityFrameworkCore;
using CrunchyPeanutButter.Domain.Stores;

namespace CrunchyPeanutButter.Data.Stores
{
    public class CrunchyPeanutButterUnitOfWork : EntityFrameworkCoreUnitOfWork<CrunchyPeanutButterDbContext>, ICrunchyPeanutButterUnitOfWork
    {
        public CrunchyPeanutButterUnitOfWork(CrunchyPeanutButterDbContext context) : base(context)
        {
        }


        public IBarRepository Bars => (IBarRepository) GetRepository(() => new BarRepository(Context.Bars));

        public IFooRepository Foos => (IFooRepository) GetRepository(() => new FooRepository(Context.Foos));
    }
}