using CrunchyPeanutButter.Domain.Abstractions.Models;

namespace CrunchyPeanutButter.Domain.Models.Bars
{
    public class Ack : IDomainEntity
    {
        public Bar Bar { get; private set; }

        public int BarId { get; private set; }

        public string Name { get; set; }
    }
}