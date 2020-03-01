using System.ComponentModel.DataAnnotations;
using MediatR;

namespace CrunchyPeanutButter.Domain.Foos.Commands
{
    public class CreateFooCommand : IRequest<Foo>
    {
        [Required]
        public string Name { get; private set; }
    }
}