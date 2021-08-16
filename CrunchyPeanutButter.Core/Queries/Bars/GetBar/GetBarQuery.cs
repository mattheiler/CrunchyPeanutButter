using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Queries.Bars.GetBar
{
    public class GetBarQuery : IRequest<GetBarQueryResult>
    {
        public Guid Id { get; set; }
    }
}