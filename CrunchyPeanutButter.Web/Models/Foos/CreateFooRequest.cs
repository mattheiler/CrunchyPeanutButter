using System;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    public class CreateFooRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}