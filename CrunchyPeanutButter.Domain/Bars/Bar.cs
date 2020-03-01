using CrispyBacon;

namespace CrunchyPeanutButter.Domain.Bars
{
    public class Bar : IAggregateRoot
    {
        public int Id { get; private set; }

        public string Name { get; set; }
    }
}