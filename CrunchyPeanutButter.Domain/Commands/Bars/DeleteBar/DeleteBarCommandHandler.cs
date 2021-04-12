using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Stores;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Bars.DeleteBar
{
    public class DeleteBarCommandHandler : ICommandHandler<DeleteBarCommand>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public DeleteBarCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bars.FindAsync(request.Id);
            if (entity == null)
                return default;

            _context.Bars.Remove(entity);

            await _context.SaveAsync(cancellationToken);

            return default;
        }
    }
}