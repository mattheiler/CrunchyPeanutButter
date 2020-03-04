using System.ComponentModel.DataAnnotations;
using CrunchyPeanutButter.Domain.Foos;
using MediatR;

namespace CrunchyPeanutButter.Api.Commands.Foos
{
    public class UpdateFooCommand : IRequest<Foo>
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}.")]
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }
    }
}