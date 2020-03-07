using System.Collections.Generic;
using CrispyBacon;

namespace CrunchyPeanutButter.Domain.Foos
{
    public class Foo : IAggregateRoot
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public ICollection<FooBar> Bars { get; } = new List<FooBar>();

        public ICollection<Baz> Bazes { get; } = new List<Baz>();
    }
}