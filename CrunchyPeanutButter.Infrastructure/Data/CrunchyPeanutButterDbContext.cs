using CrunchyPeanutButter.Core.Abstractions;
using CrunchyPeanutButter.Core.Models.Bars;
using CrunchyPeanutButter.Core.Models.Foos;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Infrastructure.Data
{
    public class CrunchyPeanutButterDbContext : DbContext, ICrunchyPeanutButterDbContext
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
                .Entity<Foo>()
                .HasMany(e => e.Bars);
        }
    }
}