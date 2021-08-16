using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Queries.Foos.GetFoo
{
    public class GetFooQuery : IRequest<GetFooQueryResult>
    {
        public Guid Id { get; set; }
    }
}