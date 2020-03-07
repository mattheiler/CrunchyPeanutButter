using System.ComponentModel.DataAnnotations;

namespace CrunchyPeanutButter.Api.Models.Bars
{
    public class BarUpdateRequest
    {
        public long Id { get; set; }


        [Required] [MaxLength(32)] public string Name { get; set; }
    }
}