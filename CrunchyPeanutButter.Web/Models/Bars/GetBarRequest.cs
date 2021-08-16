using System;
using AutoMapper;
using CrunchyPeanutButter.Core.GetBar;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(GetBarQuery), ReverseMap = true)]
    public class GetBarRequest
    {
        public Guid Id { get; set; }
    }
}