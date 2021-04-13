using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Abstractions.Stores;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Foos.CreateFoo
{
    public class CreateFooCommandHandler : IRequestHandler<CreateFooCommand>
    {
        private readonly IDbContext _context;

        public CreateFooCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = request.Foo;

            await _context.Foos.AddAsync(foo, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}