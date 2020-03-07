using System;
using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Bars.Commands;
using MediatR;

namespace CrunchyPeanutButter.Domain.Bars.CommandHandlers
{
    public class UpdateBarCommandHandler : IRequestHandler<UpdateBarCommand, Bar>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public UpdateBarCommandHandler(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Bar> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bars.FindAsync(request.Id);
            if (entity == null)
                throw new InvalidOperationException("Couldn't find the entity.");

            entity.Name = request.Name;

            _context.Bars.Update(entity);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}