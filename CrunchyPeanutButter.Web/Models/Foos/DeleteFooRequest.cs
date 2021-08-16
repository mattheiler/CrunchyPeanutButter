using System;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    public class DeleteFooRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}