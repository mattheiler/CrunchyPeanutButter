using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Foos.UpdateFoo
{
    public class UpdateFooCommandHandler : IRequestHandler<UpdateFooCommand>
    {
        private readonly IDbContext _context;

        public UpdateFooCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = request.Foo;

            _context.Foos.Update(foo);

            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}