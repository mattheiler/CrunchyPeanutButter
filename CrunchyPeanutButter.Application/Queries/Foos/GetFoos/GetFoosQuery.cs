using System.Collections.Generic;
using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Foos
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