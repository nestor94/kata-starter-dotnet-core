using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input="")
        {
            if (string.IsNullOrEmpty(input)) return 0;
            var separator = new [] {",", "\n"};
            if (input.StartsWith("//"))
            {
                separator = new [] {input.Split("\n")[0].Replace("/", "")};
                input = input.Split("\n")[1];
            }
            var query = input.Split(separator, StringSplitOptions.None);
            var numbers = query.Select(int.Parse).Where(x=> x<= 1000).ToArray();
            var negativeNumbers = numbers.Where(x => x < 0).ToArray();
            if (negativeNumbers.Any())
            {
                string exceptionNumbers = string.Join(", ", negativeNumbers);
                throw new Exception($"negatives not allowed: {exceptionNumbers}");
            }

            return numbers.Sum();
        }
    }
}