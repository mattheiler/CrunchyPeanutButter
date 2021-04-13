using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Foos
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