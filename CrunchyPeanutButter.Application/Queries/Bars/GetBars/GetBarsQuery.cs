using System.Collections.Generic;
using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Bars.GetBars
{
    public class GetBarsQuery : IRequest<List<BarViewModel>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}