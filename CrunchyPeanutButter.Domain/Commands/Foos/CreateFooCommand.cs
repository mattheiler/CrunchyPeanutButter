﻿using CrunchyPeanutButter.Domain.Aggregates.Foos;
using MediatR;

namespace CrunchyPeanutButter.Domain.Commands.Foos
{
    public class CreateFooCommand : IRequest<Foo>
    {
        public CreateFooCommand(Foo foo)
        {
            Foo = foo;
        }

        public Foo Foo { get; }
    }
}