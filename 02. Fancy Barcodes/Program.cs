using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"\@\#+([A-Z][a-zA-Z0-9]{4,}[A-Z])\@\#+";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string codes = Console.ReadLine();

                MatchCollection match = regex.Matches(codes);
                if (match.Count == 0)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                string group = FindGroup(match);
                Console.WriteLine($"Product group: {group}");
            }
        }

        private static string FindGroup(MatchCollection match)
        {
            string group = string.Empty;
            foreach (Match item in match)
            {
                string code = item.ToString();
                foreach (var currentSymbol in code)
                {
                    if (Char.IsDigit(currentSymbol))
                    {
                        group += currentSymbol;
                    }
                }
            }
            group = group != "" ? group : "00";
            return group;
        }
    }
}