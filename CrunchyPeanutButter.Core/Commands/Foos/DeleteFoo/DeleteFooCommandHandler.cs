using System;
using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Foos.DeleteFoo
{
    public class DeleteFooCommandHandler : IRequestHandler<DeleteFooCommand>
    {
        private readonly ICrunchyPeanutButterDbContext _context;

        public DeleteFooCommandHandler(ICrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
        {
            var foo = await _context.Foos.FindAsync(request.Id);
            if (foo == null)
                throw new InvalidOperationException($"Couldn't find foo with ID {request.Id}.");

            _context.Foos.Remove(foo);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}