using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core.Bars.UpdateBar
{
    public class UpdateBarCommandHandler : IRequestHandler<Foos.UpdateFoo.UpdateFooCommand>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBarCommandHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Foos.UpdateFoo.UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var bar = await _context.Bars.FindAsync(request.Id);

            _mapper.Map(request, bar);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}