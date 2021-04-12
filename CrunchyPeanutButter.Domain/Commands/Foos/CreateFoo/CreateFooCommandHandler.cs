using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Stores;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Foos.CreateFoo
{
    public class CreateFooCommandHandler : ICommandHandler<CreateFooCommand>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public CreateFooCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = request.Foo;

            await _context.Foos.AddAsync(foo, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return default;
        }
    }
}