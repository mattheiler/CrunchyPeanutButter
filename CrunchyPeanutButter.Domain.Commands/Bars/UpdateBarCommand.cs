using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Bars
{
    public class UpdateBarCommand : IRequest<Bar>
    {
        public UpdateBarCommand(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }
}