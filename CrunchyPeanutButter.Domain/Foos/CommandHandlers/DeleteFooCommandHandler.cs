using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Foos.Commands;
using MediatR;

namespace CrunchyPeanutButter.Domain.Foos.CommandHandlers
{
    public class DeleteFooCommandHandler : IRequestHandler<DeleteFooCommand, bool>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public DeleteFooCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Foos.FindAsync(request.Id);
            if (entity == null)
                return false;

            _context.Foos.Remove(entity);

            await _context.SaveAsync(cancellationToken);

            return true;
        }
    }
}