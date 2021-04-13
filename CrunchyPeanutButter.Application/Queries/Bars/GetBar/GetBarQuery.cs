using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Bars.GetBar
{
    public class GetBarQuery : IRequest<BarViewModel>
    {
        public GetBarQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}