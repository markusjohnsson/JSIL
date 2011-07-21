using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    [AttributeUsageAttribute(AttributeTargets.Class, Inherited = true)]
    public sealed class AttributeUsageAttribute: Attribute
    {
        public bool Inherited { get; set; }

        public AttributeUsageAttribute(AttributeTargets targets)
        {

        }
    }
}
