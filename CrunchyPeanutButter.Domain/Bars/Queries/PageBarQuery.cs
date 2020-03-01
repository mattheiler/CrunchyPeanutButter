using CrispyBacon.Collections;
using MediatR;

namespace CrunchyPeanutButter.Domain.Bars.Queries
{
    public class PageBarQuery : IRequest<Page<Bar>>
    {
        public int Index { get; private set; }

        public int Size { get; private set; }

        public string SortBy { get; private set; }

        public SortDirection SortDirection { get; private set; }
    }
}