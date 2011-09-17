
using JSIL.Meta;
namespace System
{
    public class String
    {
        [JSReplacement("$left === $right")]
        public extern static bool operator ==(string left, string right);

        [JSReplacement("$left !== $right")]
        public extern static bool operator !=(string left, string right);

    }
}
