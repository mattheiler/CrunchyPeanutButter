using System.Collections.Generic;
using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Bars
{
    public class GetBarsQuery : IRequest<List<GetBarsQueryResult>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}