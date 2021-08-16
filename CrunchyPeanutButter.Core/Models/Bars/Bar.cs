using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrunchyPeanutButter.Core.Models.Bars
{
    public class Bar
    {
        // Ids should be provided to aggregate roots to make the create non idempotent.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public Ack Ack { get; set; }

        // Read-only, if you need the reverse lookup, but that should be generally avoided.
        // public IReadOnlyCollection<FooBar> Foos { get; } = new List<FooBar>();
    }
}