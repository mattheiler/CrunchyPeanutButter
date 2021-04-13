using CrunchyPeanutButter.Domain.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Foos.UpdateFoo
{
    public class UpdateFooCommand : IRequest
    {
        public UpdateFooCommand(int id, Foo foo)
        {
            Id = id;
            Foo = foo;
        }

        public int Id { get; }

        public Foo Foo { get; }
    }
}