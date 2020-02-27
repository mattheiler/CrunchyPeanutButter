using CrunchyPeanutButter.Domain.Collections;
using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Domain.Queries.Bars
{
    public class PageBarQuery : IRequest<Page<Bar>>
    {
        public PageBarQuery(int index, int size, string sortBy, SortDirection sortDirection)
        {
            Index = index;
            Size = size;
            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public int Index { get; }

        public int Size { get; }

        public string SortBy { get; }

        public SortDirection SortDirection { get; }
    }
}