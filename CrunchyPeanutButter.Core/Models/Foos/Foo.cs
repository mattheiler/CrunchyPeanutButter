using System.Collections.Generic;

namespace CrunchyPeanutButter.Core.Models.Foos
{
    public class Foo
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public ICollection<FooBar> Bars { get; } = new List<FooBar>();

        public ICollection<Baz> Bazes { get; } = new List<Baz>();
    }
}