using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Foos.CreateFoo
{
    [Serializable]
    [AutoMap(typeof(Foo), ReverseMap = true)]
    public class CreateFooCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}