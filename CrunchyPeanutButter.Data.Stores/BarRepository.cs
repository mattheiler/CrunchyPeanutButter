using CrispyBacon.Stores.EntityFrameworkCore;
using CrunchyPeanutButter.Domain.Models.Bars;
using CrunchyPeanutButter.Domain.Stores;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data.Stores
{
    internal class BarRepository : EntityFrameworkCoreRepository<Bar>, IBarRepository
    {
        public BarRepository(DbSet<Bar> set) : base(set)
        {
        }
    }
}