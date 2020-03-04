﻿using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Data;
using CrunchyPeanutButter.Api.Commands.Foos;
using CrunchyPeanutButter.Domain.Foos;
using MediatR;

namespace CrunchyPeanutButter.Api.CommandHandlers.Foos
{
    public class DeleteFooCommandHandler : IRequestHandler<DeleteFooCommand, bool>
    {
        private readonly IUnitOfWork _context;

        public DeleteFooCommandHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
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