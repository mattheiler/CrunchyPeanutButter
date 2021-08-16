using System;
using MediatR;

namespace CrunchyPeanutButter.Core.GetFoo
{
    public class GetFooQuery : IRequest<GetFooQueryResult>
    {
        public Guid Id { get; set; }
    }
}