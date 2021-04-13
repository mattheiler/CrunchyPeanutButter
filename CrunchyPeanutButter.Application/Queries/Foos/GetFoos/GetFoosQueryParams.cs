namespace CrunchyPeanutButter.Application.Queries.Foos
{
    public class GetFoosQueryParams
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; } = 20;
    }
}