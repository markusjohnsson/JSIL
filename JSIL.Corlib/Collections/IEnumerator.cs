
namespace System.Collections
{
    public interface IEnumerator: IDisposable
    {
        object Current { get; }
        bool MoveNext();
    }
}
