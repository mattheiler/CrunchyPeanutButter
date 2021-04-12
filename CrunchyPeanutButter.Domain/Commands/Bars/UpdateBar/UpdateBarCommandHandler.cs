using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Stores;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Bars.UpdateBar
{
    public class UpdateBarCommandHandler : ICommandHandler<UpdateBarCommand>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public UpdateBarCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            _context.Bars.Update(bar);

            await _context.SaveAsync(cancellationToken);

            return default;
        }
    }
}