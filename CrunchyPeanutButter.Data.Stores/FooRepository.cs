using CrispyBacon.Stores.EntityFrameworkCore;
using CrunchyPeanutButter.Domain.Models.Foos;
using CrunchyPeanutButter.Domain.Stores;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data.Stores
{
    internal class FooRepository : EntityFrameworkCoreRepository<Foo>, IFooRepository
    {
        public FooRepository(DbSet<Foo> set) : base(set)
        {
        }
    }
}