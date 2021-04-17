namespace CrunchyPeanutButter.ApiClient.Abstractions
{
    public class GetBarsRequest
    {
        public int Offset { get; set; }

        public int Limit { get; set; } = 20;
    }
}