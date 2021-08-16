using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core.GetFoo
{
    // Option: use a mapping profile to get control of your maps.
    [AutoMap(typeof(Foo))]
    public class GetFooQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}