using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Commands.Bars.UpdateBar;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(UpdateBarCommand), ReverseMap = true)]
    public class UpdateBarRequest
    {
        [FromRoute]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}