using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Abstractions.Persistence;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Foos
{
    public class DeleteFooCommandHandler : IRequestHandler<DeleteFooCommand>
    {
        private readonly IDbContext _context;

        public DeleteFooCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Foos.FindAsync(request.Id);
            if (entity == null)
                return default;

            _context.Foos.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}