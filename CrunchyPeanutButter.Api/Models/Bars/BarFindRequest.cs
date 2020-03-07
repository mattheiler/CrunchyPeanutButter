using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Models.Bars
{
    public class BarFindRequest
    {
        [FromRoute]
        public long Id { get; set; }
    }
}