using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TripleTriadCustomGenerator
{
    public class Stat
    {
        private static List<int[]> LegendaryCombinations;
        private static List<int[]> RareCombinations;
        private static List<int[]> CommonCombinations;

        public static int[] CreateLegendaryStats() => FindCombinations(Rarity.Legendary, ref LegendaryCombinations);

        public static int[] CreateRare() => FindCombinations(Rarity.Rare, ref RareCombinations);
        public static int[] CreateCommon() => FindCombinations(Rarity.Commmon, ref  CommonCombinations);

        private static int[] FindCombinations(Rarity type,ref List<int[]> stats)
        {
            var rnd = new Random();

            if (stats == null)
            {
                int min;
                int max;
                switch (type)
                {
                    case Rarity.Legendary:
                        min = 24;
                        max = 29;
                        break;
                    case Rarity.Rare:
                        min = 21;
                        max = 25;
                        break;
                    case Rarity.Commmon:
                    default:
                        min = 18;
                        max = 22;
                        break;
                }

                var absolute = rnd.Next(min, max); //Generates random values with the total being 24 - 28
                Console.WriteLine($"Creating {type.ToString()} card with {absolute} as absolute value");
                stats = GFG.FindCombinations(absolute, 4);
                Console.WriteLine($"Found {stats.Count} combinations");
            }

            var index = rnd.Next(0, stats.Count);

            return stats[index].ShiftRight();
        }

        private static List<List<int>> FindCombinations(int n, int k)
        {
            //Console.WriteLine("N = " +n + " K = " +k);
            var combinationList = new List<int>();
            var resultsList = new List<List<int>>();
            CombinationUtil(k, n, 0, 1, combinationList, ref resultsList);
            return resultsList;
        }

        private static void CombinationUtil(int k, int n, int sum, int start, List<int> combinationList,
            ref List<List<int>> result)
        {
            if (k == 0)
            {
                if (sum != n) return;

                result.Add(new List<int>(combinationList));
                combinationList.ForEach(e => Console.Write(e + " "));
                Console.WriteLine();
                return;
            }

            for (var i = start; i <= 9; i++)
            {
                combinationList.Add(i);
                CombinationUtil(k - 1, n, sum + i, i + 1, combinationList, ref result);

                combinationList.RemoveAt(combinationList.Count - 1);
            }
        }

        public static int[] GetStat(Rarity type)
        {
            switch (type)
            {
                case Rarity.Legendary :
                    return CreateLegendaryStats();
                case Rarity.Rare: return CreateRare();
                case Rarity.Commmon :
                    default: return CreateCommon();
            }
        }
    }
}