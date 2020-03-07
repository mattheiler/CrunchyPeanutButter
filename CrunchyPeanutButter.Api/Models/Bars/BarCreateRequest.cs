using System.ComponentModel.DataAnnotations;

namespace CrunchyPeanutButter.Api.Models.Bars
{
    public class BarCreateRequest
    {
        [Required] [MaxLength(32)] public string Name { get; set; }
    }
}