using CrunchyPeanutButter.Domain.Models.Bars;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Bars.UpdateBar
{
    public class UpdateBarCommand : IRequest
    {
        public UpdateBarCommand(int id, Bar bar)
        {
            Id = id;
            Bar = bar;
        }

        public int Id { get; }

        public Bar Bar { get; }
    }
}