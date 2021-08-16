using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Core.Abstractions;
using CrunchyPeanutButter.Core.Foos.DeleteFoo;
using MediatR;

namespace CrunchyPeanutButter.Core.Bars.DeleteBar
{
    public class DeleteBarCommandHandler : IRequestHandler<DeleteFooCommand>
    {
        private readonly IDbContext _context;

        public DeleteBarCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
        {
            var bar = await _context.Bars.FindAsync(request.Id);

            _context.Bars.Remove(bar);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}