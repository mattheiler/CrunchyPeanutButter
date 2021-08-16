using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Abstractions;
using CrunchyPeanutButter.Core.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Core.Foos.CreateFoo
{
    public class CreateFooCommandHandler : IRequestHandler<CreateFooCommand>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public CreateFooCommandHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = _mapper.Map<Foo>(request);

            await _context.Foos.AddAsync(foo, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}