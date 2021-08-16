using System;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    public class UpdateFooRequest
    {
        [FromRoute]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}