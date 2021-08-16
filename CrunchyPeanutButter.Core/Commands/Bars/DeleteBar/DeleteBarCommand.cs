using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Core.Bars.DeleteBar
{
    [Serializable]
    [AutoMap(typeof(Foo))]
    public class DeleteBarCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}