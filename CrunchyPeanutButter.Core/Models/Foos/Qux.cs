namespace CrunchyPeanutButter.Core.Models.Foos
{
    public class Qux
    {
        public int Id { get; private set; }

        public Baz Baz { get; private set; }

        public int BazId { get; private set; }

        public string Name { get; set; }
    }
}