using CrunchyPeanutButter.Domain.Abstractions.Models;

namespace CrunchyPeanutButter.Domain.Models.Bars
{
    public class Bar : IDomainEntity
    {
        public Bar(Ack ack)
        {
            Ack = ack;
        }

        private Bar()
        {
        }

        public int Id { get; private set; }

        public string Name { get; set; }

        public Ack Ack { get; private set; }

        public Fum Fum { get; private set; } = new Fum();
    }
}