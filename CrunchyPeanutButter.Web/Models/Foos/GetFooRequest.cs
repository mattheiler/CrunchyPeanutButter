using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Queries.Foos.GetFoo;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(GetFooQuery), ReverseMap = true)]
    public class GetFooRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}