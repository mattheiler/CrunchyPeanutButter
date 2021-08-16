using System;

namespace CrunchyPeanutButter.Web.Models.Bars
{
    public class CreateBarRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}