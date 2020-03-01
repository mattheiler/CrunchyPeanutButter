using System;
using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Data;
using CrunchyPeanutButter.Domain.Bars;
using CrunchyPeanutButter.Domain.Bars.Commands;
using MediatR;

namespace CrunchyPeanutButter.Api.CommandHandlers.Bars
{
    public class UpdateBarCommandHandler : IRequestHandler<UpdateBarCommand, Bar>
    {
        private readonly IUnitOfWork _context;

        public UpdateBarCommandHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Bar> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var repository = _context.GetRepository<Bar>();

            var entity = await repository.FindAsync(request.Id);
            if (entity == null)
                throw new InvalidOperationException("Couldn't find the entity.");

            repository.Update(entity);

            await _context.SaveAsync(cancellationToken);

            return entity;
        }
    }
}