namespace CrunchyPeanutButter.ApiClient.Abstractions
{
    public class GetFoosRequest
    {
        public int Offset { get; set; }

        public int Limit { get; set; } = 20;
    }
}