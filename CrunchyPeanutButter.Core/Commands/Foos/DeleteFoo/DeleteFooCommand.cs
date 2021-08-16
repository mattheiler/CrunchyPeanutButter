using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Core.Foos.DeleteFoo
{
    [Serializable]
    [AutoMap(typeof(Foo))]
    public class DeleteFooCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}