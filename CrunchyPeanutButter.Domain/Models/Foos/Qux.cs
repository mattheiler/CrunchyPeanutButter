﻿using CrunchyPeanutButter.Domain.Abstractions.Models;

namespace CrunchyPeanutButter.Domain.Models.Foos
{
    public class Qux : IDomainEntity
    {
        public int Id { get; private set; }

        public Baz Baz { get; private set; }

        public int BazId { get; private set; }

        public string Name { get; set; }
    }
}