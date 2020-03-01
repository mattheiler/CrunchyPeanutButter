using System;
using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Data;
using CrunchyPeanutButter.Domain.Foos;
using CrunchyPeanutButter.Domain.Foos.Commands;
using MediatR;

namespace CrunchyPeanutButter.Api.CommandHandlers.Foos
{
    public class UpdateFooCommandHandler : IRequestHandler<UpdateFooCommand, Foo>
    {
        private readonly IUnitOfWork _context;

        public UpdateFooCommandHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Foo> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var repository = _context.GetRepository<Foo>();

            var entity = await repository.FindAsync(request.Id);
            if (entity == null)
                throw new InvalidOperationException("Couldn't find the entity.");

            repository.Update(entity);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}