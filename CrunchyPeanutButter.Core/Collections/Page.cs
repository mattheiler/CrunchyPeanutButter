using System.Collections.Generic;
using System.Linq;

namespace CrunchyPeanutButter.Core.Collections
{
    public class Page<T>
    {
        public Page(IEnumerable<T> items, int count)
        {
            Count = count;
            Items = items.ToList().AsReadOnly();
        }

        public int Count { get; }

        public IReadOnlyList<T> Items { get; }
    }
}