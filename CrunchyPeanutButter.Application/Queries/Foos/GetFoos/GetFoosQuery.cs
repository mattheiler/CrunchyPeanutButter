using System.Collections.Generic;
using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Foos
{
    public class GetFoosQuery : IRequest<List<GetFoosQueryResult>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}