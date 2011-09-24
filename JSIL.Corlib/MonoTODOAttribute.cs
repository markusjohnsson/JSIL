using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    internal class MonoTODOAttribute : Attribute
    {
        public MonoTODOAttribute(string message)
        {
        }
        public MonoTODOAttribute()
        {

        }
    }
    internal class MonoLimitationAttribute : Attribute
    {
        public MonoLimitationAttribute(string message)
        {
        }
        public MonoLimitationAttribute()
        {

        }
    }
    internal class MonoNotSupported : Attribute
    {
        public MonoNotSupported(string message)
        {

        }
        public MonoNotSupported()
        {

        }
    }
}
