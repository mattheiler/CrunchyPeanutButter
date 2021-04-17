using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Application.Abstractions.Persistence;
using CrunchyPeanutButter.Domain.Events.Bars;
using CrunchyPeanutButter.Domain.Models.Bars;
using MediatR;

namespace CrunchyPeanutButter.Application
{
    public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand>
    {
        private readonly IDbContext _context;

        private readonly IMapper _mapper;

        private readonly IPublisher _publisher;

        public CreateBarCommandHandler(IDbContext context, IMapper mapper, IPublisher publisher)
        {
            _context = context;
            _mapper = mapper;
            _publisher = publisher;
        }

        public async Task<Unit> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = _mapper.Map(request.Args, new Bar(new Ack()));

            await _context.Bars.AddAsync(bar, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await _publisher.Publish(new BarCreatedEvent(bar), cancellationToken);

            return default;
        }
    }
}