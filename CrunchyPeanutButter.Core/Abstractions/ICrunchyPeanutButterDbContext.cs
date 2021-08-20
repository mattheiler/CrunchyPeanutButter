using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Core.Models.Bars;
using CrunchyPeanutButter.Core.Models.Foos;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Core.Abstractions
{
    public interface ICrunchyPeanutButterDbContext
    {
        DbSet<Bar> Bars { get; }

        DbSet<Foo> Foos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}