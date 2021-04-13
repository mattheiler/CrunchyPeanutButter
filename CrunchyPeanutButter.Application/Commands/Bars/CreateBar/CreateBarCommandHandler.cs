using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application.Abstractions.Stores;
using CrunchyPeanutButter.Domain.Events.Bars;
using MediatR;

namespace CrunchyPeanutButter.Application.Commands.Bars.CreateBar
{
    public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand>
    {
        private readonly IDbContext _context;

        private readonly IPublisher _publisher;

        public CreateBarCommandHandler(IDbContext context, IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task<Unit> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            await _context.Bars.AddAsync(bar, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            await _publisher.Publish(new BarCreatedEvent(bar), cancellationToken);

            return default;
        }
    }
}