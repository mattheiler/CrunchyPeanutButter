using System.Collections.Generic;

namespace CrunchyPeanutButter.Domain.Models.Foos
{
    public class Baz
    {
        public int Id { get; private set; }

        public Foo Foo { get; private set; }

        public int FooId { get; private set; }

        public string Name { get; set; }

        public ICollection<Qux> Quxes { get; } = new List<Qux>();
    }
}