using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Core.Collections;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Core.Extensions
{
    public static class PageExtensions
    {
        public static async Task<Page<T>> ToPageAsync<T>(this IQueryable<T> @this, int offset, int limit, CancellationToken cancellationToken)
        {
            var count = await @this.CountAsync(cancellationToken);
            var items = await @this.Skip(offset).Take(limit).ToListAsync(cancellationToken);
            return new Page<T>(items, count);
        }
    }
}
