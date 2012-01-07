
using JSIL.Proxy;
using JSIL.Meta;
using JSIL;
using System.Collections;
using System.Collections.Generic;
namespace System
{
    // FIXME: AnyType is meaningless to have in Corlib
    // FIXME: All methods should be implemented in JSIL.Core.js (we don't want to use prototype on Arrays (TraceMonkey perf issue?))

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

        [JSReplacement("Array.prototype.indexOf.call($array, $value, $startIndex)")]
        public extern static int IndexOf(Array array, object value, int startIndex, int count);

        [JSReplacement("Array.prototype.indexOf.call($array, $value)")]
        public extern static int IndexOf<T>(T[] array, T value);

        [JSReplacement("Array.prototype.indexOf.call($array, $value, $startIndex)")]
        public extern static int IndexOf<T>(T[] array, T value, int startIndex);

        [JSReplacement("Array.prototype.indexOf.call($array, $value, $startIndex)")]
        public extern static int IndexOf<T>(T[] _items, T item, int index, int count);

        public static void Clear(Array array, int index, int length)
        {
            var isPrimitive = array.GetType().GetElementType().IsPrimitive;
            Verbatim.Expression(@"
                var defaultValue = isPrimitive ? 0 : null;
                
                for (var i = 0; i<length; i++)
                    array[i+index] = defaultValue;
            ");
        }

        [JSReplacement("$this.slice(0)")]
        public extern object Clone();

        public static void Copy(
            Array sourceArray,
            int sourceIndex,
            Array destinationArray,
            int destinationIndex,
            int length)
        {
            Verbatim.Expression(@"
                var values = [];

                for (var i=0; i<lenght; i++)
                    values.push(sourceArray[i + sourceIndex]);

                for (var i=0; i<lenght; i++)
                    destinationArray[i+destinationIndex] = values[i];
            ");
        }

        public int Rank
        {
            get
            {
                return 1;
            }
        }

        public void SetValue(object value, int index)
        {
            Verbatim.Expression("this[index] = value");
        }

        public static int BinarySearch(Array array, int index, int length, Object value)
        {
            throw new NotImplementedException();
        }

        public static int BinarySearch(Array array, int index, int length, Object value, IComparer comparer)
        {
            throw new NotImplementedException();
        }

        public static void Sort(Array array, int index, int length)
        {
            throw new NotImplementedException();
        }

        public static int LastIndexOf(Array array, object value, int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public static int LastIndexOf<T>(T[] array, T value, int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public static void Reverse(Array array, int index, int count)
        {
            throw new NotImplementedException();
        }

        public static void Copy(Array source, Array dest, int length)
        {
            Verbatim.Expression(@"
                for (var i = 0; i<length; i++)
                    dest[i] = source[i];
            ");
        }

        public static void Sort(Array array, int start, int count, IComparer comparer)
        {
            throw new NotImplementedException();
        }

        public static void Sort<T>(T[] array, int index, int length)
        {
            throw new NotImplementedException();
        }

        public static void Sort<T>(T[] array,
            int index,
            int length,
            IComparer<T> comparer)
        {
            throw new NotImplementedException();
        }

        internal static void SortImpl<T>(T[] array, int index, Comparison<T> comparison)
        {
            throw new NotImplementedException();
        }

        internal static void Resize<T>(ref T[] array, int newSize)
        {
            if (newSize < 0)
                throw new ArgumentOutOfRangeException();

            if (array == null)
            {
                array = new T[newSize];
                return;
            }

            int length = array.Length;
            if (length == newSize)
                return;

            T[] a = new T[newSize];
            if (length != 0)
                FastCopy(array, 0, a, 0, Math.Min(newSize, length));
            array = a; 
        }

        private static void FastCopy<T>(T[] array, int p, T[] a, int p_2, int p_3)
        {
            for (int i = 0; i < array.Length; i++)
            {
                a[i] = array[i];
            }
        }

        public int GetLowerBound(int p)
        {
            throw new NotImplementedException();
        }

        internal static int BinarySearch<T>(T[] array, int index, int count, object value, IComparer<T> comparer)
        {
            throw new NotImplementedException();
        }

        internal static int BinarySearch<T>(T[] array, int index, int count, object value)
        {
            throw new NotImplementedException();
        }

        public int GetLength(int dimension)
        {
            throw new NotImplementedException();
        }
    }
}
