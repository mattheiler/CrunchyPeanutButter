using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Application.Abstractions.Stores;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Application.Queries.Foos.GetFoos
{
    public class GetFoosQueryHandler : IRequestHandler<GetFoosQuery, List<FooViewModel>>
    {
        private readonly IDbContext _context;

        private readonly IConfigurationProvider _mappings;

        public GetFoosQueryHandler(IDbContext context, IConfigurationProvider mappings)
        {
            _context = context;
            _mappings = mappings;
        }

        public Task<List<FooViewModel>> Handle(GetFoosQuery request, CancellationToken cancellationToken)
        {
            return
                _context
                    .Foos
                    .OrderBy(foo => foo.Id)
                    .Skip(request.PageSize * request.PageIndex)
                    .Take(request.PageSize)
                    .ProjectTo<FooViewModel>(_mappings)
                    .ToListAsync(cancellationToken);
        }
    }
}