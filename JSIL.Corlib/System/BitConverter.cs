using System;
using System.Collections.Generic;
using System.Text;
using JSIL;

namespace System
{
    public static class BitConverter
    {
        public static double Int64ToDoubleBits(long source)
        {
            Verbatim.Expression(@"
            var arrayBuffer = new ArrayBuffer(8);
            var int32buffer = new Int32Array(arrayBuffer);
            int32buffer.set([source.low_, source.high_]);
            var doubleBuffer = new Float64Array(arrayBuffer);
            return doubleBuffer[0];
            ");
            throw new NotSupportedException();
        }

        public static long DoubleToInt64Bits(double source)
        {
            Verbatim.Expression(@"
            var arrayBuffer = new ArrayBuffer(8);
            var doubleBuffer = new Float64Array(arrayBuffer);
            doubleBuffer.set([source]);
            var int32buffer = new Int32Array(arrayBuffer);
            var low = int32buffer[0];
            var high = int32buffer[1];
            return goog.math.Long.fromBits(low, high);
            ");
            throw new NotSupportedException();
        }
    }
}
