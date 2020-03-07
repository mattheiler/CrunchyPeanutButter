using System.ComponentModel.DataAnnotations;
using MediatR;

namespace CrunchyPeanutButter.Domain.Bars.Commands
{
    public class CreateBarCommand : IRequest<Bar>
    {
        [Required] public string Name { get; private set; }
    }
}