using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Aggregates.Bars;
using CrunchyPeanutButter.Domain.Commands.Bars;
using CrunchyPeanutButter.Domain.Events;
using CrunchyPeanutButter.Domain.Stores;
using MediatR;

namespace CrunchyPeanutButter.Domain.Services
{
    public class BarService :
        IRequestHandler<CreateBarCommand, Bar>,
        IRequestHandler<UpdateBarCommand, Bar>,
        IRequestHandler<DeleteBarCommand, bool>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        private readonly IMediator _mediator;

        public BarService(ICrunchyPeanutButterUnitOfWork context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Bar> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            await _context.Bars.AddAsync(bar, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            await _mediator.Publish(new BarCreatedEvent(bar), cancellationToken);

            return bar;
        }

        public async Task<Bar> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = request.Bar;

            _context.Bars.Update(bar);

            await _context.SaveAsync(cancellationToken);

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
    }
}