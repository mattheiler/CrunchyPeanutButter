﻿using CrunchyPeanutButter.Domain.Models.Bars;

namespace CrunchyPeanutButter.Domain.Models.Foos
{
    public class FooBar
    {
        private FooBar(Bar bar)
        {
            Bar = bar;
        }


        private FooBar()
        {
        }

        public Foo Foo { get; private set; }

        public int FooId { get; private set; }

        public Bar Bar { get; private set; }

        public int BarId { get; private set; }
    }
}