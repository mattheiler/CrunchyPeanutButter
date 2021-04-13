using System.Collections.Generic;
using CrunchyPeanutButter.Domain.Abstractions.Models;

namespace CrunchyPeanutButter.Domain.Models.Foos
{
    public class Baz : IDomainEntity
    {
        public int Id { get; private set; }

        public Foo Foo { get; private set; }

        public int FooId { get; private set; }

        public string Name { get; set; }

        public ICollection<Qux> Quxes { get; } = new List<Qux>();
    }
}