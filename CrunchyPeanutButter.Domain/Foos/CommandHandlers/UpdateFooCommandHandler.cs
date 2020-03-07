using System;
using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Foos.Commands;
using MediatR;

namespace CrunchyPeanutButter.Domain.Foos.CommandHandlers
{
    public class UpdateFooCommandHandler : IRequestHandler<UpdateFooCommand, Foo>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public UpdateFooCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Foo> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Foos.FindAsync(request.Id);
            if (entity == null)
                throw new InvalidOperationException("Couldn't find the entity.");

            entity.Name = request.Name;

            _context.Foos.Update(entity);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}