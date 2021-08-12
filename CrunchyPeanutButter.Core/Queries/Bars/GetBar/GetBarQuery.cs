using MediatR;

namespace CrunchyPeanutButter.Core
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