using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Foos.UpdateFoo
{
    [Serializable]
    public class UpdateFooCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}