using MediatR;

namespace CrunchyPeanutButter.Domain.Foos.Queries
{
    public class FindFooQuery : IRequest<Foo>
    {
        public int Id { get; private set; }
    }
}