using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Commands.Bars;
using MediatR;

namespace CrunchyPeanutButter.Data.CommandHandlers.Bars
{
    public class DeleteBarCommandHandler : IRequestHandler<DeleteBarCommand, bool>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public DeleteBarCommandHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bars.FindAsync(request.Id);
            if (entity == null)
                return false;

            _context.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}