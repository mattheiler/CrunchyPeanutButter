using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Commands;
using CrispyBacon.Events;
using CrunchyPeanutButter.Domain.Commands.Bars;
using CrunchyPeanutButter.Domain.Events;
using CrunchyPeanutButter.Domain.Models.Bars;
using CrunchyPeanutButter.Domain.Stores;

namespace CrunchyPeanutButter.Domain.Services
{
    public class BarService :
        ICommandHandler<CreateBarCommand, Bar>,
        ICommandHandler<UpdateBarCommand, Bar>,
        ICommandHandler<DeleteBarCommand, bool>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        private readonly IEventDispatcher _events;

        public BarService(ICrunchyPeanutButterUnitOfWork context, IEventDispatcher events)
        {
            _context = context;
            _events = events;
        }

        public async Task<Bar> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            await _context.Bars.AddAsync(bar, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            await _events.DispatchAsync(new BarCreatedEvent(bar), cancellationToken);

            return bar;
        }

        public async Task<bool> Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bars.FindAsync(request.Id);
            if (entity == null)
                return false;

            _context.Bars.Remove(entity);

            await _context.SaveAsync(cancellationToken);

            return true;
        }

        public async Task<Bar> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            _context.Bars.Update(bar);

            await _context.SaveAsync(cancellationToken);

            return bar;
        }
    }
}