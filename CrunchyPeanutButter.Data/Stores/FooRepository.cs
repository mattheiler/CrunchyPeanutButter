using CrispyBacon.Data.EntityFrameworkCore;
using CrunchyPeanutButter.Domain.Aggregates.Foos;
using CrunchyPeanutButter.Domain.Stores;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data.Stores
{
    internal class FooRepository : DbSetRepository<Foo>, IFooRepository
    {
        public FooRepository(DbSet<Foo> set) : base(set)
        {
        }
    }
}