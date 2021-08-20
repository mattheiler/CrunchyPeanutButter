using System;
using System.Collections.Generic;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core.Models.Bars
{
    public class Bar
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Ack Ack { get; set; }

        public IReadOnlyCollection<Foo> Foos { get; } = new List<Foo>();
    }
}