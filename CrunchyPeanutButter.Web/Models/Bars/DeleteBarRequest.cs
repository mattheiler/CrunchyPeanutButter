using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Bars.DeleteBar;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(DeleteBarCommand), ReverseMap = true)]
    public class DeleteBarRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}