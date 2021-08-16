using System;
using MediatR;

namespace CrunchyPeanutButter.Core.GetBar
{
    public class GetBarQuery : IRequest<GetBarQueryResult>
    {
        public Guid Id { get; set; }
    }
}