using CrunchyPeanutButter.Domain.Models.Bars;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Bars.CreateBar
{
    public class CreateBarCommand : IRequest
    {
        public CreateBarCommand(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }
}