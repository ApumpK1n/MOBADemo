using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ClassAttribute : Attribute
    {
        public Type AttributeType { get; }

        public ClassAttribute()
        {
            AttributeType = GetType();
        }
    }
}
