using CrunchyPeanutButter.Core.Collections;
using MediatR;

namespace CrunchyPeanutButter.Core.GetBars
{
    public class GetBarsQuery : IRequest<Page<GetBarsQueryResult>>
    {
        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}