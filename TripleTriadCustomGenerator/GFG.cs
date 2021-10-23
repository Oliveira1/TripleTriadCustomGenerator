using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualBasic.CompilerServices;

namespace TripleTriadCustomGenerator
{
    // C# program to find out all
// combinations of positive numbers
// that add upto given number
    using System;

    public static class GFG
    {
/* arr - array to store the
combination
index - next location in array
num - given number
reducedNum - reduced number */
        private static void FindCombinationsUtil(int[] arr, int index,
            int num, int reducedNum, int limit, ref List<int[]> possibleCombinations)
        {
            switch (reducedNum)
            {
                // Base condition
                case < 0:
                case 0 when index < limit:
                    return;
                // If combination is
                // found, print it
                case 0 when arr.Length == limit:
                {
                    var cArr = new int[limit];
                    arr.CopyTo(cArr, 0);
                    /*
                    for (int i = 0; i < index; i++)
                        Console.Write (arr[i] + " ");
                    Console.WriteLine();
                    */
                    possibleCombinations.Add(cArr);
                    return;
                }
            }

            if (index >= arr.Length)
            {
                return;
            }

            // Find the previous number
            // stored in arr[]. It helps
            // in maintaining increasing
            // order
            var prev = (index == 0) ? 1 : arr[index - 1];

            // note loop starts from
            // previous number i.e. at
            // array location index - 1
            for (var k = prev; k <= 9; k++)
            {
                // next element of
                // array is k
                arr[index] = k;

                // call recursively with
                // reduced number
                FindCombinationsUtil(arr, index + 1, num,
                    reducedNum - k, limit, ref possibleCombinations);
            }
        }

/* Function to find out all
combinations of positive
numbers that add upto given
number. It uses findCombinationsUtil() */
        public static List<int[]> FindCombinations(int n, int k)
        {
            // array to store the combinations
            // It can contain max n elements
            var arr = new int [k];
            var possibleCombinations = new List<int[]>();
            // find all combinations
            FindCombinationsUtil(arr, 0, n, n, k, ref possibleCombinations);
            return possibleCombinations;
        }

// This code is contributed
// by akt_mit
    }
}