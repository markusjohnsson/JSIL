
using JSIL.Meta;

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
    }
}
