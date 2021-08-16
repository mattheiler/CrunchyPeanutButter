using System;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    public class DeleteBarRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}