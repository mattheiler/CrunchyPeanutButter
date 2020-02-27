using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Bars
{
    public class CreateBarCommand : IRequest<Bar>
    {
        public CreateBarCommand(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }
}