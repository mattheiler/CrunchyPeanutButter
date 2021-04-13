using MediatR;

namespace CrunchyPeanutButter.Application.Queries.Foos.GetFoo
{
    public class GetFooQuery : IRequest<FooViewModel>
    {
        public GetFooQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}