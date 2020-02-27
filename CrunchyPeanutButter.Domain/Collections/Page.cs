using System.Collections.Generic;
using System.Linq;

namespace CrunchyPeanutButter.Domain.Collections
{
    public class Page<T>
    {
        public Page(int index, int size, int count, IEnumerable<T> items)
        {
            Index = index;
            Size = size;
            Count = count;
            Items = items.ToList().AsReadOnly();
        }

        public IReadOnlyCollection<T> Items { get; }

        public int Index { get; }

        public int Size { get; }

        public int Count { get; }
    }
}