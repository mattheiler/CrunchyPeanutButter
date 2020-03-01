using MediatR;

namespace CrunchyPeanutButter.Domain.Bars.Queries
{
    public class FindBarQuery : IRequest<Bar>
    {
        public int Id { get; private set; }
    }
}