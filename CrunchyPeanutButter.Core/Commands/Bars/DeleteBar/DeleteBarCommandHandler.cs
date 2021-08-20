using System;
using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Bars.DeleteBar
{
    public class DeleteBarCommandHandler : IRequestHandler<DeleteBarCommand>
    {
        private readonly ICrunchyPeanutButterDbContext _context;

        public DeleteBarCommandHandler(ICrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            var bar = await _context.Bars.FindAsync(request.Id);
            if (bar == null)
                throw new InvalidOperationException($"Couldn't find bar with ID {request.Id}.");

            _context.Bars.Remove(bar);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}