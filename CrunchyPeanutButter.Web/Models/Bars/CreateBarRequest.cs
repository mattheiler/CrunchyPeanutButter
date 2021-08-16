using System;
using AutoMapper;
using CrunchyPeanutButter.Core.Commands.Bars.CreateBar;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    [AutoMap(typeof(CreateBarCommand), ReverseMap = true)]
    public class CreateBarRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}