using System.ComponentModel.DataAnnotations;
using CrunchyPeanutButter.Domain.Bars;
using MediatR;

namespace CrunchyPeanutButter.Api.Commands.Bars
{
    public class CreateBarCommand : IRequest<Bar>
    {
        [Required]
        public string Name { get; private set; }
    }
}