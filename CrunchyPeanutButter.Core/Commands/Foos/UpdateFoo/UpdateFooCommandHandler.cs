using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;

namespace CrunchyPeanutButter.Core.Foos.UpdateFoo
{
    public class UpdateFooCommandHandler : IRequestHandler<UpdateFooCommand>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public UpdateFooCommandHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = await _context.Foos.FindAsync(request.Id);

            _mapper.Map(request, foo);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }

}