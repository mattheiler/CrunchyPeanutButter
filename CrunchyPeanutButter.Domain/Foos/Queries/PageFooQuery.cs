using CrispyBacon.Collections;
using MediatR;

namespace CrunchyPeanutButter.Domain.Foos.Queries
{
    public class PageFooQuery : IRequest<Page<Foo>>
    {
        public int Index { get; private set; }

        public int Size { get; private set; }

        public string SortBy { get; private set; }

        public SortDirection SortDirection { get; private set; }
    }
}