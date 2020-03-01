using System.ComponentModel.DataAnnotations;
using MediatR;

namespace CrunchyPeanutButter.Domain.Bars.Commands
{
    public class DeleteBarCommand : IRequest<bool>
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}.")]
        public int Id { get; private set; }
    }
}