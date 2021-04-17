﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CrunchyPeanutButter.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrunchyPeanutButter.Api.Controllers
{
    [Route("bars")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly ISender _sender;

        public BarController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:int}")]
        public Task<GetBarQueryResult> GetBarAsync(int id)
        {
            return _sender.Send(new GetBarQuery(id));
        }

        [HttpGet]
        public Task<List<GetBarsQueryResult>> GetBarsAsync([FromQuery] GetBarsQueryParams @params)
        {
            return _sender.Send(new GetBarsQuery(@params));
        }

        [HttpPost]
        public Task CreateAsync(CreateBarCommandArgs args)
        {
            return _sender.Send(new CreateBarCommand(args));
        }

        [HttpPut("{id:int}")]
        public Task UpdateAsync(int id, UpdateBarCommandArgs args)
        {
            return _sender.Send(new UpdateBarCommand(id, args));
        }

        [HttpDelete("{id:int}")]
        public Task DeleteAsync(int id)
        {
            return _sender.Send(new DeleteBarCommand(id));
        }
    }
}