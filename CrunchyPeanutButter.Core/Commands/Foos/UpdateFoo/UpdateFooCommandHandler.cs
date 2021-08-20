using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Foos.UpdateFoo
{
    public class UpdateFooCommandHandler : IRequestHandler<UpdateFooCommand>
    {
        private readonly ICrunchyPeanutButterDbContext _context;
        private readonly IMapper _mapper;

        public UpdateFooCommandHandler(ICrunchyPeanutButterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = await _context.Foos.FindAsync(request.Id);
            if (foo == null)
                throw new InvalidOperationException($"Couldn't find foo with ID {request.Id}.");

            _mapper.Map(request, foo);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }

}