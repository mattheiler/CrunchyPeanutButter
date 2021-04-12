using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Domain.Commands.Bars.CreateBar
{
    public class CreateBarCommand : ICommand
    {
        public CreateBarCommand(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }
}