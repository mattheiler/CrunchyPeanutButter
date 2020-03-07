using CrispyBacon;

namespace CrunchyPeanutButter.Domain.Bars
{
    public class Bar : IAggregateRoot
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public Ack Ack { get; private set; } = new Ack();

        public Fum Fum { get; private set; } = new Fum();
    }
}