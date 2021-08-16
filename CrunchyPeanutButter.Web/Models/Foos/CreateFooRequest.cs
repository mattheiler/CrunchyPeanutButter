using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Foos.CreateFoo;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(CreateFooCommand), ReverseMap = true)]
    public class CreateFooRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}