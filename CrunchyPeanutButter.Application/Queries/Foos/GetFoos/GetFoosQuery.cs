using System.Collections.Generic;
using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Foos.GetFoos
{
    public class GetFoosQuery : IRequest<List<FooViewModel>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}