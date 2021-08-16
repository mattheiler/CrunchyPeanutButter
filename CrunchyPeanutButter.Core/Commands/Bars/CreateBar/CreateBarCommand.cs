using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Bars;
using MediatR;

namespace CrunchyPeanutButter.Core.Bars.CreateBar
{
    [Serializable]
    [AutoMap(typeof(Bar), ReverseMap = true)]
    public class CreateBarCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}