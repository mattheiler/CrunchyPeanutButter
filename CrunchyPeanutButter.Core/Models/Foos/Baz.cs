using System;

namespace CrunchyPeanutButter.Core.Models.Foos
{
    public class Baz
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Code { get; private set; }

        // This is read-only and set by the principal end - the aggregate root.
        public Foo Foo { get; private set; }

        public Guid FooId { get; private set; }
    }
}