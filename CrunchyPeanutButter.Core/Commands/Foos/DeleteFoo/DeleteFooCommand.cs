using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Foos.DeleteFoo
{
    [Serializable]
    public class DeleteFooCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}