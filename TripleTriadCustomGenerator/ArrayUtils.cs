using System.Runtime.CompilerServices;

namespace TripleTriadCustomGenerator
{
    public static class ArrayUtils
    {
        public static int[] ShiftRight(this int[] arr)
        {
            var t = arr[^1];
            for (var i = arr.Length - 1; i > 0; i--)
                arr[i] = arr[i - 1];
            arr[0] = t;
            return arr;
        }
    }
}