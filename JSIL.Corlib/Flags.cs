using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    [AttributeUsageAttribute(AttributeTargets.Enum, Inherited = false)]
    public class Flags: Attribute
    {
    }
}
