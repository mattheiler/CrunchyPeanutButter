using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Commands.Foos.UpdateFoo;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(UpdateFooCommand), ReverseMap = true)]
    public class UpdateFooRequest
    {
        [FromRoute]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}