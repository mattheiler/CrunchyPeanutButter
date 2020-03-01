using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Data;
using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Bars.Commands;
using MediatR;

namespace CrunchyPeanutButter.Data.CommandHandlers.Bars
{
    public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand, Bar>
    {
        private readonly IUnitOfWork _context;

        public CreateBarCommandHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Bar> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var repository = _context.GetRepository<Bar>();

            var entity = new Bar {Name = request.Name};

            await _context.GetRepository<Bar>().AddAsync(entity, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}