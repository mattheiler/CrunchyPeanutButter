using System.ComponentModel.DataAnnotations;
using MediatR;

namespace CrunchyPeanutButter.Api.Commands.Bars
{
    public class DeleteBarCommand : IRequest<bool>
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}.")]
        public int Id { get; private set; }
    }
}