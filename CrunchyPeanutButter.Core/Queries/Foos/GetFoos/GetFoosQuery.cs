using System.Collections.Generic;
using MediatR;

namespace CrunchyPeanutButter.Core
{
    public class GetFoosQuery : IRequest<List<GetFoosQueryResult>>
    {
        public GetFoosQuery(GetFoosQueryParams @params)
        {
            Params = @params;
        }

        public GetFoosQueryParams Params { get; }
    }
}