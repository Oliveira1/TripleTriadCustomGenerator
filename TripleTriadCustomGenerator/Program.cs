using System;
using System.Data;
using System.IO;
using TripleTriadCustomGenerator.DrawBorder;

namespace TripleTriadCustomGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string common =
                @"C:\Users\bruno.paixao.FARFETCH\Documents\repositories\shenannigans\TripleTriadCustomGenerator\TripleTriadCustomGenerator\Common";
            const string rare =
                @"C:\Users\bruno.paixao.FARFETCH\Documents\repositories\shenannigans\TripleTriadCustomGenerator\TripleTriadCustomGenerator\Rare";
            const string legendary =
                @"C:\Users\bruno.paixao.FARFETCH\Documents\repositories\shenannigans\TripleTriadCustomGenerator\TripleTriadCustomGenerator\Legendary";
            DrawCard(legendary, Rarity.Legendary);
            DrawCard(rare, Rarity.Rare);
            DrawCard(common, Rarity.Commmon);
            Console.WriteLine("Finished");
        }

        private static void DrawCard(string legendary, Rarity type)
        {
            var i = 0;

            foreach (var filePath in Directory.GetFiles(legendary))
            {
                Console.WriteLine("Drawing card...");
                ImageEdit.DrawBorder(type, Stat.GetStat(type), filePath, type.ToString() + i++);
            }
        }
    }
}