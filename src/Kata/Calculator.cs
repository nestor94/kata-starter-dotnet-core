using System;

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
            int sum = 0;
            
            var numbers = input.Split(separator, StringSplitOptions.None);
            foreach (var number in numbers)
            {
                sum += int.Parse(number);
            }
            return sum;
        }
    }
}