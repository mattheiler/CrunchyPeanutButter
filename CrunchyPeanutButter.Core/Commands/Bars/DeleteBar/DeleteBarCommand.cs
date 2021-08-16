using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Bars.DeleteBar
{
    [Serializable]
    [AutoMap(typeof(Foo))]
    public class DeleteBarCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}