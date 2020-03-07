namespace CrunchyPeanutButter.Queries.Foos
{
    public class FooDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int[] BarIds { get; set; }

        public FooDetailsQux Qux { get; set; }
    }
}