using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Bars.Commands;
using MediatR;

namespace CrunchyPeanutButter.Domain.Bars.CommandHandlers
{
    public class DeleteBarCommandHandler : IRequestHandler<DeleteBarCommand, bool>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public DeleteBarCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bars.FindAsync(request.Id);
            if (entity == null)
                return false;

            _context.Bars.Remove(entity);

            await _context.SaveAsync(cancellationToken);

            return true;
        }
    }
}