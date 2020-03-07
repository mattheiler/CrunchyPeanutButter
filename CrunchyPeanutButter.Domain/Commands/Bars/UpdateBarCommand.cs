using CrunchyPeanutButter.Domain.Aggregates.Bars;
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