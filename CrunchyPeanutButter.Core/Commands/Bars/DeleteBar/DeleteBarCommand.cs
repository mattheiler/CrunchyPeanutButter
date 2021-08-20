using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Bars.DeleteBar
{
    [Serializable]
    public class DeleteBarCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}