using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Collections;
using Microsoft.EntityFrameworkCore;


namespace CrunchyPeanutButter.Data.Paging
{
    public static class Page
    {
        public static async Task<Page<TSource>> ToPageAsync<TSource>(this IQueryable<TSource> queryable, int index, int size)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));
            if (index < 0) throw new ArgumentException("Index must be greater than or equal to 0.", nameof(index));
            if (size <= 0) throw new ArgumentException("Size must be greater than 0.", nameof(size));

            var count = await queryable.CountAsync();
            var items = await queryable.Skip(index * size).Take(size).ToListAsync();

            return new Page<TSource>(index, size, count, items);
        }

        public static async Task<Page<TResult>> ToPageAsync<TSource, TResult>(this IQueryable<TSource> queryable, int index, int size, Expression<Func<TSource, TResult>> resultSelector)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));
            if (index < 0) throw new ArgumentException("Index must be greater than or equal to 0.", nameof(index));
            if (size <= 0) throw new ArgumentException("Size must be greater than 0.", nameof(size));

            var count = await queryable.CountAsync();
            var items = await queryable.Skip(index * size).Take(size).Select(resultSelector).ToListAsync();

            return new Page<TResult>(index, size, count, items);
        }
    }
}
