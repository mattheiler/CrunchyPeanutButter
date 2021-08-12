using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core
{
    public class UpdateBarCommandHandler : IRequestHandler<UpdateBarCommand>
    {
        private readonly IDbContext _context;

        private readonly IMapper _mapper;

        public UpdateBarCommandHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var bar = await _context.Bars.FindAsync(request.Id);

            _mapper.Map(request.Args, bar);

            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}