using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Application.Queries.Foos.GetFoo
{
    public class GetFooQueryHandler : IRequestHandler<GetFooQuery, FooViewModel>
    {
        private readonly IDbContext _context;

        private readonly IConfigurationProvider _mappings;

        public GetFooQueryHandler(IDbContext context, IConfigurationProvider mappings)
        {
            _context = context;
            _mappings = mappings;
        }

        public Task<FooViewModel> Handle(GetFooQuery request, CancellationToken cancellationToken)
        {
            return
                _context
                    .Foos
                    .Select(foo => foo.Id == request.Id)
                    .ProjectTo<FooViewModel>(_mappings)
                    .SingleOrDefaultAsync(cancellationToken);
        }
    }
}