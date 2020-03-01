using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrispyBacon.Collections;
using Microsoft.EntityFrameworkCore;

namespace CrispyBacon.Data.EntityFrameworkCore.Collections
{
    public static class Page
    {
        public static Task<Page<TSource>> ToPageAsync<TSource>(this IQueryable<TSource> queryable, int index, int size)
        {
            return ToPageAsyncImpl(queryable, index, size, results => results);
        }

        public static Task<Page<TResult>> ToPageAsync<TSource, TResult>(this IQueryable<TSource> queryable, int index, int size, Expression<Func<TSource, TResult>> transformer)
        {
            return ToPageAsyncImpl(queryable, index, size, results => results.Select(transformer));
        }

        private static async Task<Page<TResult>> ToPageAsyncImpl<TSource, TResult>(this IQueryable<TSource> queryable, int index, int size, Func<IQueryable<TSource>, IQueryable<TResult>> selector)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));
            if (index < 0) throw new ArgumentException("Index must be greater than 0.", nameof(index));
            if (size <= 0) throw new ArgumentException("Size must be greater than or equal to 0.", nameof(size));

            var count = await queryable.CountAsync();
            var items = await selector(queryable.Skip(index * size).Take(size)).ToListAsync();

            return new Page<TResult>(index, size, count, items);
        }
    }
}