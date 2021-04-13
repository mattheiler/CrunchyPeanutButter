using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Bars
{
    public class GetBarQuery : IRequest<GetBarQueryResult>
    {
        public GetBarQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}