using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core.Queries.Foos.GetFoo
{
    [AutoMap(typeof(Foo))]
    public class GetFooQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}