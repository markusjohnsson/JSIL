
namespace System.Reflection
{
    public class DefaultMemberAttribute: Attribute
    {
        public string MemberName { get; set; }

        public DefaultMemberAttribute(string name)
        {
            MemberName = name;
        }
    }
}
