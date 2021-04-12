using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Stores;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Foos.UpdateFoo
{
    public class UpdateFooCommandHandler : ICommandHandler<UpdateFooCommand>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public UpdateFooCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = request.Foo;

            _context.Foos.Update(foo);

            await _context.SaveAsync(cancellationToken);

            return default;
        }
    }
}