using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Commands;
using CrispyBacon.Events;
using CrunchyPeanutButter.Domain.Events;
using CrunchyPeanutButter.Domain.Stores;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Bars.CreateBar
{
    public class CreateBarCommandHandler : ICommandHandler<CreateBarCommand>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        private readonly IDomainEventDispatcher _domainEvents;

        public CreateBarCommandHandler(ICrunchyPeanutButterUnitOfWork context, IDomainEventDispatcher domainEvents)
        {
            _context = context;
            _domainEvents = domainEvents;
        }

        public async Task<Unit> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            await _context.Bars.AddAsync(bar, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            await _domainEvents.DispatchAsync(new BarCreatedEvent(bar), cancellationToken);

            return default;
        }
    }
}