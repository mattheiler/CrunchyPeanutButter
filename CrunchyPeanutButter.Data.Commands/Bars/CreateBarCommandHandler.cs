using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Commands.Bars;
using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Data.Commands.Bars
{
    public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand, Bar>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public CreateBarCommandHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<Bar> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var entry = await _context.Bars.AddAsync(request.Bar, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entry.Entity;
        }
    }
}