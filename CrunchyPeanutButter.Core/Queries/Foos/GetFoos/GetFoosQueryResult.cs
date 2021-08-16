using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Models.Foos;

namespace CrunchyPeanutButter.Core.GetFoos
{
    // Option: use a mapping profile to get control of your maps.
    [AutoMap(typeof(Foo))]
    public class GetFoosQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}