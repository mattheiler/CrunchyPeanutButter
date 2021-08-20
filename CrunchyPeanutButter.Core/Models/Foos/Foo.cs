using System;
using System.Collections.Generic;
using CrunchyPeanutButter.Core.Models.Bars;

namespace CrunchyPeanutButter.Core.Models.Foos
{
    public class Foo
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<Bar> Bars { get; } = new List<Bar>();

        public ICollection<Baz> Bazs { get; } = new List<Baz>();
    }
}