using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Abstract
{
    public class RegexDemo : Demo
    {
        public override void Run()
        {
            string input = "What is -12 divided by 2 divided by -3?";
            string pattern = @"(-?\d+)|(\bplus\b|\bminus\b|\btimes\b|\bdivided by\b)";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                if (match.Groups[1].Success)
                {
                    Console.WriteLine($"Number: {match.Groups[1].Value}");
                }
                else if (match.Groups[2].Success)
                {
                    Console.WriteLine($"Operation: {match.Groups[2].Value}");
                }
            }

            RegexBasics();
        }

        private static void RegexBasics()
        {
            string input = "What is 5?";
            string pattern = @"\d+"; // Pattern to match one or more digits

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                int number = int.Parse(match.Value);
                Console.WriteLine($"Extracted number: {number}");
            }

            string question = "What is 5 plus 13 plus 6 ?";
            Match questionMatch = Regex.Match(question, @"^What is (?<firstNumber>-?\d+)(?<operation>[^-\d]+)(?<secondNumber>-?\d+)(?<rest>.+)?");
            if (!questionMatch.Success) throw new ArgumentException();

            int firstNumber = int.Parse(questionMatch.Groups["firstNumber"].Value);
            int secondNumber = int.Parse(questionMatch.Groups["secondNumber"].Value);
        }
    }



}

