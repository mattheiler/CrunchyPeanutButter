using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CrunchyPeanutButter.Core.Abstractions;
using CrunchyPeanutButter.Core.Models.Foos;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Foos.CreateFoo
{
    public class CreateFooCommandHandler : IRequestHandler<CreateFooCommand>
    {
        private readonly ICrunchyPeanutButterDbContext _context;
        private readonly IMapper _mapper;

        public CreateFooCommandHandler(ICrunchyPeanutButterDbContext context, IMapper mapper)
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