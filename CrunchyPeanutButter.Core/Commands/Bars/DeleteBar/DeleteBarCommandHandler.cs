using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Bars.DeleteBar
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
            var bar = await _context.Bars.FindAsync(request.Id);

            _context.Bars.Remove(bar);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}