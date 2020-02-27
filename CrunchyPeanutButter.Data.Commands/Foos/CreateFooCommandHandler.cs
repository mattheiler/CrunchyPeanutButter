using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Commands.Foos;
using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Data.Commands.Foos
{
    public class CreateFooCommandHandler : IRequestHandler<CreateFooCommand, Foo>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public CreateFooCommandHandler(CrunchyPeanutButterDbContext workspace)
        {
            _context = workspace;
        }

        public async Task<Foo> Handle(CreateFooCommand request, CancellationToken cancellationToken)
        {
            var entry = await _context.Foos.AddAsync(request.Foo, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entry.Entity;
        }
    }
}