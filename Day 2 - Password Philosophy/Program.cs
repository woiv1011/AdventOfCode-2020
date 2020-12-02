using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_2___Password_Philosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines(@"passwordInput.txt");
            int count = inputs.Where(line => IsValidPassword(line)).Count(); //should return 600
            int count2 = inputs.Where(line => IsValidPassword_SecondPolicy(line)).Count(); //245
        }

        static bool IsValidPassword(string passwordLine)
        {
            string regexPattern = @"^(?<min>\d+)[-](?<max>\d+)\s(?<letter>.)[:]\s(?<password>\w+$)";
            var temp = regexPattern.Length;
            var match = Regex.Match(passwordLine, regexPattern);
            int min = Int32.Parse(match.Groups["min"].Value);
            int max = Int32.Parse(match.Groups["max"].Value);
            char letter = Char.Parse(match.Groups["letter"].Value);
            string password = match.Groups["password"].Value;

            var letterCount = password.Count(c => c == letter);

            return (letterCount >= min && letterCount <= max);
        }

        static bool IsValidPassword_SecondPolicy(string passwordLine)
        {
            string regexPattern = @"^(?<pos1>\d+)[-](?<pos2>\d+)\s(?<letter>.)[:]\s(?<password>\w+$)";
            var temp = regexPattern.Length;
            var match = Regex.Match(passwordLine, regexPattern);
            int pos1 = Int32.Parse(match.Groups["pos1"].Value);
            int pos2 = Int32.Parse(match.Groups["pos2"].Value);
            char letter = Char.Parse(match.Groups["letter"].Value);
            string password = match.Groups["password"].Value;

            bool firstPos = (pos1 - 1) < password.Length ? password[(pos1 - 1)] == letter : false;
            bool secondPos = (pos2 - 1) < password.Length ? password[(pos2 - 1)] == letter : false;
            return (firstPos ^ secondPos);
        }
    }
}
