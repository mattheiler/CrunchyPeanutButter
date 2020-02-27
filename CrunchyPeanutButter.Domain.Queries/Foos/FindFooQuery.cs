using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Domain.Queries.Foos
{
    public class FindFooQuery : IRequest<Foo>
    {
        public FindFooQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}