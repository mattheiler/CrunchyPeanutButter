using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Queries.Foos.GetFoo;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(GetFooQueryResult))]
    public class GetFooResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}