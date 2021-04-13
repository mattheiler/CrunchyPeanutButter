using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Bars.DeleteBar
{
    public class DeleteBarCommandHandler : IRequestHandler<DeleteBarCommand>
    {
        private readonly IDbContext _context;

        public DeleteBarCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bars.FindAsync(request.Id);
            if (entity == null)
                return default;

            _context.Bars.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}