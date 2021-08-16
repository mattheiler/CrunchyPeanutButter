using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Foos.DeleteFoo
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
            var foo = await _context.Foos.FindAsync(request.Id);

            _context.Foos.Remove(foo);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}