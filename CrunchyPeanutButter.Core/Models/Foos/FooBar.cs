using System;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core.Models.Foos
{
    public class FooBar
    {
        private FooBar()
        {
        }

        public FooBar(Bar bar)
        {
            Bar = bar;
        }

        // This is read-only and set by the principal end - the aggregate root.
        public Foo Foo { get; private set; }

        public Guid FooId { get; private set; }

        // This is set only once - on create - and should only be set in the constructor, since this is a relationship entity.
        // Consider making this a shadow entity in Entity Framework 5.0+.
        public Bar Bar { get; private set; }

        public Guid BarId { get; private set; }
    }
}