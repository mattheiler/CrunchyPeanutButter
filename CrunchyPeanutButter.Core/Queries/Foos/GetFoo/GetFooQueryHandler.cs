using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Core.Queries.Foos.GetFoo
{
    public class GetFooQueryHandler : IRequestHandler<GetFooQuery, GetFooQueryResult>
    {
        private readonly ICrunchyPeanutButterDbContext _context;
        private readonly IConfigurationProvider _mapping;

        public GetFooQueryHandler(ICrunchyPeanutButterDbContext context, IConfigurationProvider mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<GetFooQueryResult> Handle(GetFooQuery request, CancellationToken cancellationToken)
        {
            var results =
                await _context
                    .Foos
                    .Where(foo => foo.Id == request.Id)
                    .ProjectTo<GetFooQueryResult>(_mapping)
                    .SingleAsync(cancellationToken);
            return results;
        }
    }
}