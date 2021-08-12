using CrunchyPeanutButter.Core.Abstractions.Persistence;
using CrunchyPeanutButter.Core.Models.Bars;
using CrunchyPeanutButter.Core.Models.Foos;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Persistence
{
    public class CrunchyPeanutButterDbContext : DbContext, IDbContext
    {
        public CrunchyPeanutButterDbContext(DbContextOptions<CrunchyPeanutButterDbContext> options)
            : base(options)
        {
        }

        public CrunchyPeanutButterDbContext()
        {
        }

        public DbSet<Foo> Foos { get; set; }

        public DbSet<Bar> Bars { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model
                .Entity<Ack>()
                .HasKey(e => e.BarId);

            model
                .Entity<Bar>()
                .OwnsOne(e => e.Fum);

            model
                .Entity<FooBar>()
                .HasKey(e => new {e.FooId, e.BarId});
        }
    }
}