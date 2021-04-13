﻿using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Models.Bars;
using CrunchyPeanutButter.Domain.Models.Foos;
using Microsoft.EntityFrameworkCore;

namespace CrunchyPeanutButter.Application.Abstractions
{
    public interface IDbContext
    {
        DbSet<Bar> Bars { get; }

        DbSet<Foo> Foos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}