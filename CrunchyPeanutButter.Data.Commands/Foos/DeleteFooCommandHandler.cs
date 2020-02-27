using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Commands.Foos;
using MediatR;

namespace CrunchyPeanutButter.Data.Commands.Foos
{
    public class DeleteFooCommandHandler : IRequestHandler<DeleteFooCommand, bool>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public DeleteFooCommandHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
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