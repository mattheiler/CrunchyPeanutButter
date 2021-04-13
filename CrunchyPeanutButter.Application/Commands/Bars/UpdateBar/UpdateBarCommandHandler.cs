using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Bars.UpdateBar
{
    public class UpdateBarCommandHandler : IRequestHandler<UpdateBarCommand>
    {
        private readonly IDbContext _context;

        public UpdateBarCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            _context.Bars.Update(bar);

            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}