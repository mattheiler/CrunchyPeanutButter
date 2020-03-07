namespace CrunchyPeanutButter.Api.Models
{
    public abstract class PageResponse<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public T[] Items { get; set; }
    }
}