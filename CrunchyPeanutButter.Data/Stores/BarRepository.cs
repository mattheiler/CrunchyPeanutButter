using CrispyBacon.Data.EntityFrameworkCore;
using CrunchyPeanutButter.Domain.Aggregates.Bars;
using CrunchyPeanutButter.Domain.Stores;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data.Stores
{
    internal class BarRepository : DbSetRepository<Bar>, IBarRepository
    {
        public BarRepository(DbSet<Bar> set) : base(set)
        {
        }
    }
}