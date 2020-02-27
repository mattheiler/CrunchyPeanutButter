using System.Collections.Generic;

namespace CrunchyPeanutButter.Domain.Models
{
    public class Foo
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public ICollection<FooBar> Bars { get; } = new List<FooBar>();
    }

    public class FooBar
    {
        private FooBar(Bar bar)
        {
            Bar = bar;
        }


        private FooBar()
        {
        }

        public Foo Foo { get; private set; }

        public int FooId { get; private set; }

        public Bar Bar { get; private set; }

        public int BarId { get; private set; }
    }
}