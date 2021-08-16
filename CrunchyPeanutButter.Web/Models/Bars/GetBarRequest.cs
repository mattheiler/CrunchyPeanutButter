using System;
using AutoMapper;
using CrunchyPeanutButter.Core.GetBar;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(GetBarQuery), ReverseMap = true)]
    public class GetBarRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}