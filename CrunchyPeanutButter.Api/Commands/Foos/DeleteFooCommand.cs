using System.ComponentModel.DataAnnotations;
using MediatR;

namespace CrunchyPeanutButter.Api.Commands.Foos
{
    public class DeleteFooCommand : IRequest<bool>
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}.")]
        public int Id { get; private set; }
    }
}