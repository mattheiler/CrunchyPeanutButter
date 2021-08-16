using System;

namespace CrunchyPeanutButter.Core.Models.Bars
{
    public class Ack
    {
        // This is read-only and set by the principal end - the aggregate root.
        public Bar Bar { get; private set; }

        public Guid BarId { get; private set; }
    }
}