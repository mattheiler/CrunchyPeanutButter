namespace CrunchyPeanutButter.Application.Queries.Bars
{
    public class GetBarsQueryParams
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; } = 20;
    }
}