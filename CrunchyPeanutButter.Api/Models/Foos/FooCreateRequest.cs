using System.ComponentModel.DataAnnotations;

namespace CrunchyPeanutButter.Api.Models.Foos
{
    public class FooCreateRequest
    {
        [Required] [MaxLength(32)] public string Name { get; set; }
    }
}