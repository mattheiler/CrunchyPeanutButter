using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Bars.UpdateBar
{
    public class UpdateBarCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}