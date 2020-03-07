using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Foos.Commands;
using MediatR;

namespace CrunchyPeanutButter.Domain.Foos.CommandHandlers
{
    public class CreateFooCommandHandler : IRequestHandler<CreateFooCommand, Foo>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public CreateFooCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Foo> Handle(CreateFooCommand request, CancellationToken cancellationToken)
        {
            var entity = new Foo {Name = request.Name};

            await _context.Foos.AddAsync(entity, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}