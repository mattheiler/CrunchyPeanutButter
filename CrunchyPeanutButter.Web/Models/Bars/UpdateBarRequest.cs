using System;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    public class UpdateBarRequest
    {
        [FromRoute]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}