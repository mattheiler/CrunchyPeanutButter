using CrunchyPeanutButter.Core.Collections;
using MediatR;

namespace CrunchyPeanutButter.Core.GetFoos
{
    public class GetFoosQuery : IRequest<Page<GetFoosQueryResult>>
    {
        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}