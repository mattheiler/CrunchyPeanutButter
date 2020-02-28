using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Commands.Bars;
using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Data.CommandHandlers.Bars
{
    public class UpdateBarCommandHandler : IRequestHandler<UpdateBarCommand, Bar>
    {
        private readonly CrunchyPeanutButterDbContext _context;

        public UpdateBarCommandHandler(CrunchyPeanutButterDbContext context)
        {
            _context = context;
        }

        public async Task<Bar> Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var entry = _context.Bars.Update(request.Bar);

            await _context.SaveChangesAsync(cancellationToken);

            return entry.Entity;
        }
    }
}