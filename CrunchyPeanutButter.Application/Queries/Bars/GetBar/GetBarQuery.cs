using MediatR;

namespace CrunchyPeanutButter.Application
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