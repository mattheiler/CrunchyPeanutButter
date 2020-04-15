using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Domain.Commands.Bars
{
    public class CreateBarCommand : ICommand<Bar>
    {
        public CreateBarCommand(Bar bar)
        {
            Bar = bar;
        }

        public Bar Bar { get; }
    }
}