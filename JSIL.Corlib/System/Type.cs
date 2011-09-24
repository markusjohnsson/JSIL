
using System.Reflection;

namespace System
{
    public class Type
    {
        public string Name { get; set; }

        public Assembly Assembly { get; set; }

        public Type GetElementType()
        {
            throw new NotImplementedException();
        }

        public bool IsPrimitive { get { return false; } }

        public bool IsAssignableFrom(Type src)
        {
            return true;
        }

        public bool IsValueType { get; set; }

        public string FullName { get; set; }

        public bool IsInstanceOfType(object p)
        {
            throw new NotImplementedException();
        }

        public bool IsGenericType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string AssemblyQualifiedName { get; set; }

        public Type GetGenericTypeDefinition()
        {
            throw new NotImplementedException();
        }

        public Type [] GetGenericArguments()
        {
            throw new NotImplementedException();
        }

        public static Type GetTypeFromHandle(RuntimeTypeHandle runtimeTypeHandle)
        {
            throw new NotImplementedException();
        }

        public Type MakeGenericType(params Type[] genericArguments)
        {
            throw new NotImplementedException();
        }
    }
}
