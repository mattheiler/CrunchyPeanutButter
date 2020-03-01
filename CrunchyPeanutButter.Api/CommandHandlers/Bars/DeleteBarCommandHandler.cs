using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Data;
using CrunchyPeanutButter.Domain.Bars.Commands;
using CrunchyPeanutButter.Domain.Foos;
using MediatR;

namespace CrunchyPeanutButter.Api.CommandHandlers.Bars
{
    public class DeleteBarCommandHandler : IRequestHandler<DeleteBarCommand, bool>
    {
        private readonly IUnitOfWork _context;

        public DeleteBarCommandHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            var repository = _context.GetRepository<Foo>();

            var entity = await repository.FindAsync(request.Id);
            if (entity == null)
                return false;

            repository.Remove(entity);

            await _context.SaveAsync(cancellationToken);

            return true;
        }
    }
}