using MediatR;

namespace CrunchyPeanutButter.Core
{
    public class GetFooQuery : IRequest<GetFooQueryResult>
    {
        public GetFooQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}