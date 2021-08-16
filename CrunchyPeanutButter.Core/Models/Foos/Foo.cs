using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrunchyPeanutButter.Core.Models.Foos
{
    public class Foo
    {
        // Ids should be provided to aggregate roots to make the create non idempotent.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public ICollection<FooBar> Bars { get; } = new List<FooBar>();

        public ICollection<Baz> Bazs { get; } = new List<Baz>();
    }
}