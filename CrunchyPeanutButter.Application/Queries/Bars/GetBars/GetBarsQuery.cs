using System.Collections.Generic;
using MediatR;

namespace CrunchyPeanutButter.Application
{
    public class GetBarsQuery : IRequest<List<GetBarsQueryResult>>
    {
        public GetBarsQuery(GetBarsQueryParams @params)
        {
            Params = @params;
        }

        public GetBarsQueryParams Params { get; }
    }
}