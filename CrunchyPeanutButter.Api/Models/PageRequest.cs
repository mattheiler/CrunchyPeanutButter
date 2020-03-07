using CrispyBacon.Collections;

namespace CrunchyPeanutButter.Api.Models
{
    public abstract class PageRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string SortBy { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}