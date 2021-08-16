using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Core.Foos.UpdateFoo
{
    [Serializable]
    [AutoMap(typeof(Foo))]
    public class UpdateFooCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}