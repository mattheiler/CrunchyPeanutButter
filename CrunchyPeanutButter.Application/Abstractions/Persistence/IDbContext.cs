using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Models.Bars;
using CrunchyPeanutButter.Domain.Models.Foos;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Application.Abstractions.Persistence
{
    public interface IDbContext
    {
        DbSet<Bar> Bars { get; }

        DbSet<Foo> Foos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default);
    }
}