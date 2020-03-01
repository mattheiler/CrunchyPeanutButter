using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Foos;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Data
{
    public class CrunchyPeanutButterDbContext : DbContext
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
                .Entity<FooBar>()
                .HasKey(e => new {e.FooId, e.BarId});
        }
    }
}