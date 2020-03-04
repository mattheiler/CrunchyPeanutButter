using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Data;
using CrunchyPeanutButter.Api.Commands.Foos;
using CrunchyPeanutButter.Domain.Foos;
using MediatR;

namespace CrunchyPeanutButter.Api.CommandHandlers.Foos
{
    public class CreateFooCommandHandler : IRequestHandler<CreateFooCommand, Foo>
    {
        private readonly IUnitOfWork _context;

        public CreateFooCommandHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Foo> Handle(CreateFooCommand request, CancellationToken cancellationToken)
        {
            var repository = _context.GetRepository<Foo>();

            var entity = new Foo { Name = request.Name };

            await repository.AddAsync(entity, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}