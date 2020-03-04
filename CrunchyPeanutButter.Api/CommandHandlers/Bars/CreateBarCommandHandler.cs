using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Data;
using CrunchyPeanutButter.Api.Commands.Bars;
using CrunchyPeanutButter.Domain.Bars;
using MediatR;

namespace CrunchyPeanutButter.Api.CommandHandlers.Bars
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

            await repository.AddAsync(entity, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}