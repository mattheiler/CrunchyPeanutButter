using System.ComponentModel.DataAnnotations;
using CrunchyPeanutButter.Domain.Bars;
using MediatR;

namespace CrunchyPeanutButter.Api.Commands.Bars
{
    public class UpdateBarCommand : IRequest<Bar>
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}.")]
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }
    }
}