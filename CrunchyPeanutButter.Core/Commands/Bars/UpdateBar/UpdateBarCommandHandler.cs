using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Bars.UpdateBar
{
    public class UpdateBarCommandHandler : IRequestHandler<UpdateBarCommand>
    {
        private readonly ICrunchyPeanutButterDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBarCommandHandler(ICrunchyPeanutButterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = await _context.Bars.FindAsync(request.Id);
            if (bar == null)
                throw new InvalidOperationException($"Couldn't find bar with ID {request.Id}.");

            _mapper.Map(request, bar);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}