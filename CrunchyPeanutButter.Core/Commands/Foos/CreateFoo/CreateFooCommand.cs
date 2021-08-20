using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Foos.CreateFoo
{
    [Serializable]
    public class CreateFooCommand : IRequest
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}