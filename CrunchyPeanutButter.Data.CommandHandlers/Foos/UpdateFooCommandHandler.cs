using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Commands.Foos;
using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Data.CommandHandlers.Foos
{
    public class UpdateFooCommandHandler : IRequestHandler<UpdateFooCommand, Foo>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public UpdateFooCommandHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<Foo> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var entry = _context.Foos.Update(request.Foo);

            await _context.SaveChangesAsync(cancellationToken);

            return entry.Entity;
        }
    }
}