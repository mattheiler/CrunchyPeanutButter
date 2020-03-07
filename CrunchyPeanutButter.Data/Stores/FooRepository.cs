using CrispyBacon.Data.EntityFrameworkCore;
using CrunchyPeanutButter.Domain.Foos;
using CrunchyPeanutButter.Domain.Foos.Stores;
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