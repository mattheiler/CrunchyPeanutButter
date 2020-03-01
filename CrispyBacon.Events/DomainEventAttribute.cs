using System;

namespace CrispyBacon.Events
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DomainEventAttribute : Attribute
    {
        public DomainEventAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}