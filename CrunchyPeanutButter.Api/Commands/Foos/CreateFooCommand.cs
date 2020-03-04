using System.ComponentModel.DataAnnotations;
using CrunchyPeanutButter.Domain.Foos;
using MediatR;

namespace CrunchyPeanutButter.Api.Commands.Foos
{
    public class CreateFooCommand : IRequest<Foo>
    {
        [Required]
        public string Name { get; private set; }
    }
}