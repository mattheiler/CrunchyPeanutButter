﻿using System.Threading.Tasks;
using CrispyBacon.Collections;
using CrunchyPeanutButter.Domain.Commands.Foos.CreateFoo;
using CrunchyPeanutButter.Domain.Commands.Foos.DeleteFoo;
using CrunchyPeanutButter.Domain.Commands.Foos.UpdateFoo;
using CrunchyPeanutButter.Domain.Models.Foos;
using CrunchyPeanutButter.Queries.Facades;
using CrunchyPeanutButter.Queries.Models.Foos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("foos")]
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IFooQueries _queries;

        public FooController(IMediator mediator, IFooQueries queries)
        {
            _mediator = mediator;
            _queries = queries;
        }

        [HttpGet("{id:long}")]
        public Task<FooDetails> FindAsync(long id)
        {
            return _queries.FindAsync(id);
        }

        [HttpGet]
        public Task<Page<FooHeader>> PageAsync(int pageIndex, int pageSize, string sortBy = nameof(Foo.Id), SortDirection sortDirection = default)
        {
            return _queries.PageAsync(sortBy, sortDirection, pageIndex, pageSize);
        }

        [HttpPost]
        public Task CreateAsync(Foo foo)
        {
            return _mediator.Send(new CreateFooCommand(foo));
        }

        [HttpPut("{id:long}")]
        public Task UpdateAsync(long id, Foo foo)
        {
            return _mediator.Send(new UpdateFooCommand(foo));
        }

        [HttpDelete("{id:long}")]
        public Task DeleteAsync(long id)
        {
            return _mediator.Send(new DeleteFooCommand(id));
        }
    }
}