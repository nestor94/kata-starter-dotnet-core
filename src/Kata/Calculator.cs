using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input="")
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var separators = new [] {",", "\n"};
            var userInput = input;

            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split("\n");

                separators = new[]
                {
                    parts
                        .First()
                        .Replace("//", "")
                };
                userInput = parts.Last();
            }
            
            var numbers = userInput
                .Split(separators, StringSplitOptions.None)
                .Select(int.Parse)
                .Where(x => x <= 1000)
                .ToArray();

            var negativeNumbers = numbers.Where(x => x < 0).ToArray();
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return numbers.Sum();

        }
    }
}