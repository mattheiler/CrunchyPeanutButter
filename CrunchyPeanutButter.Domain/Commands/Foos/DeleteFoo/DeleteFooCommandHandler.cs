using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Stores;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Foos.DeleteFoo
{
    public class DeleteFooCommandHandler : ICommandHandler<DeleteFooCommand>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public DeleteFooCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Foos.FindAsync(request.Id);
            if (entity == null)
                return default;

            _context.Foos.Remove(entity);

            await _context.SaveAsync(cancellationToken);

            return default;
        }
    }
}