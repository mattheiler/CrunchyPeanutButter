using System.Collections.Generic;

namespace CrunchyPeanutButter.Domain.Models.Foos
{
    public class Foo
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public ICollection<FooBar> Bars { get; } = new List<FooBar>();

        public ICollection<Baz> Bazes { get; } = new List<Baz>();
    }
}