using System.Collections.Generic;
using MediatR;

namespace CrunchyPeanutButter.Application
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