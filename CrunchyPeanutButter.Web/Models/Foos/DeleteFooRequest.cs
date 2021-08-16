using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Foos.DeleteFoo;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(DeleteFooCommand), ReverseMap = true)]
    public class DeleteFooRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}