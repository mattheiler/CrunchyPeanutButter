using System;
using AutoMapper;
using CrunchyPeanutButter.Core.GetFoo;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(GetFooQuery), ReverseMap = true)]
    public class GetFooRequest
    {
        public Guid Id { get; set; }
    }
}