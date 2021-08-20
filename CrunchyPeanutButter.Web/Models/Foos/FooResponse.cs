using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Queries.Foos.GetFoo;
using CrunchyPeanutButter.Core.Queries.Foos.GetFoos;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(GetFooQueryResult))]
    [AutoMap(typeof(GetFoosQueryResult))]
    public class FooResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}