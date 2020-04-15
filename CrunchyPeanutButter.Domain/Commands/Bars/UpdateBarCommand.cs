using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Domain.Commands.Bars
{
    public class UpdateBarCommand : ICommand<Bar>
    {
        public UpdateBarCommand(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }
}