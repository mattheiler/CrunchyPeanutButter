using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core.Queries.Foos.GetFoos
{
    [AutoMap(typeof(Foo))]
    public class GetFoosQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}