
using JSIL.Meta;
using JSIL;

namespace System
{
    public class Object
    {
        [JSReplacement("JSIL.GetType($this)")]
        [JSIsPure]
        public extern Type GetType();

        [JSExternal]
        protected extern object MemberwiseClone();

        [JSExternal]
        [JSIsPure]
        public extern virtual bool Equals(object obj);

        [JSChangeName("toString")]
        [JSExternal]
        public extern virtual string ToString();

        [JSExternal]
        public extern virtual int GetHashCode();

        protected static bool Equals(object o1, object o2)
        {
            if (o1 == o2)
                return true;
            if ((o1 == null) || (o2 == null))
                return false;

            return o1.Equals(o2);
        }

        public static bool ReferenceEquals(object obj1, object obj2)
        {
            return (bool)Verbatim.Expression("obj1 === obj2");
        }
    }
}
