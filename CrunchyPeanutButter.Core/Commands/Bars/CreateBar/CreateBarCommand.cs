using System;
using MediatR;

namespace CrunchyPeanutButter.Core.Commands.Bars.CreateBar
{
    [Serializable]
    public class CreateBarCommand : IRequest
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}