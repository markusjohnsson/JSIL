
using JSIL.Proxy;
using JSIL.Meta;
namespace System
{
    public abstract class Array
    {
        [JSChangeName("length")]
        [JSNeverReplace]
        abstract public int Length { get; }

        [JSReplacement("JSIL.Array.New($elementType, $size)")]
        public extern static System.Array CreateInstance(Type elementType, Int32 size);

        [JSReplacement("JSIL.MultidimensionalArray.New.apply(null, [$elementType].concat($sizes))")]
        public extern static System.Array CreateInstance(Type elementType, AnyType[] sizes);

        [JSReplacement("JSIL.MultidimensionalArray.New($elementType, $sizeX, $sizeY)")]
        public extern static System.Array CreateInstance(Type elementType, AnyType sizeX, AnyType sizeY);

        [JSReplacement("JSIL.MultidimensionalArray.New($elementType, $sizeX, $sizeY, $sizeZ)")]
        public extern static System.Array CreateInstance(Type elementType, AnyType sizeX, AnyType sizeY, AnyType sizeZ);

        [JSExternal]
        [JSRuntimeDispatch]
        public abstract void Set(params AnyType[] values);

        [JSExternal]
        [JSRuntimeDispatch]
        public abstract AnyType Get(params AnyType[] values);

        [JSReplacement("$this.Get.apply($this, $indices)")]
        public abstract AnyType GetValue(AnyType[] indices);

        [JSReplacement("$this.Set.apply($this, $indices.concat([$value]))")]
        public abstract void SetValue(AnyType value, AnyType[] indices);

        [JSReplacement("Array.prototype.indexOf.call($array, $value)")]
        public extern static int IndexOf(AnyType[] array, AnyType value);

        [JSReplacement("Array.prototype.indexOf.call($array, $value, $startIndex)")]
        public extern static int IndexOf(AnyType[] array, AnyType value, int startIndex);

        [JSReplacement("Array.prototype.indexOf.call($array, $value)")]
        public extern static int IndexOf<T>(T[] array, T value);

        [JSReplacement("Array.prototype.indexOf.call($array, $value, $startIndex)")]
        public extern static int IndexOf<T>(T[] array, T value, int startIndex);
    }
}
