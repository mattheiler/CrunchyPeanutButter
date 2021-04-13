using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Abstractions;
using CrunchyPeanutButter.Domain.Abstractions.Events;
using CrunchyPeanutButter.Domain.Events.Bars;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Bars.CreateBar
{
    public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand>
    {
        private readonly IDbContext _context;

        private readonly IDomainEventDispatcher _events;

        public CreateBarCommandHandler(IDbContext context, IDomainEventDispatcher events)
        {
            _context = context;
            _events = events;
        }

        public async Task<Unit> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            await _context.Bars.AddAsync(bar, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            await _events.Publish(new BarCreatedEvent(bar), cancellationToken);

            return default;
        }
    }
}