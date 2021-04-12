using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Domain.Commands.Bars.UpdateBar
{
    public class UpdateBarCommand : ICommand
    {
        public UpdateBarCommand(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }
}