﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrunchyPeanutButter.Application.Abstractions.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Application
{
    public class GetFooQueryHandler : IRequestHandler<GetFooQuery, GetFooQueryResult>
    {
        private readonly IDbContext _context;

        private readonly IConfigurationProvider _mappings;

        public GetFooQueryHandler(IDbContext context, IConfigurationProvider mappings)
        {
            _context = context;
            _mappings = mappings;
        }

        public Task<GetFooQueryResult> Handle(GetFooQuery request, CancellationToken cancellationToken)
        {
            return
                _context
                    .Foos
                    .Select(foo => foo.Id == request.Id)
                    .ProjectTo<GetFooQueryResult>(_mappings)
                    .SingleOrDefaultAsync(cancellationToken);
        }
    }
}