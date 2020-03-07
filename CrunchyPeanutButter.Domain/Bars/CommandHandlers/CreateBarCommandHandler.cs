using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Bars.Commands;
using MediatR;

namespace CrunchyPeanutButter.Domain.Bars.CommandHandlers
{
    public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand, Bar>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public CreateBarCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Bar> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var entity = new Bar {Name = request.Name};

            await _context.Bars.AddAsync(entity, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}