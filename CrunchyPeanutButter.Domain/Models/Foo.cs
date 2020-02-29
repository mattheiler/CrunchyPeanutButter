using System.Collections.Generic;

namespace CrunchyPeanutButter.Domain.Models
{
    public class Foo
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public ICollection<FooBar> Bars { get; } = new List<FooBar>();
    }
}