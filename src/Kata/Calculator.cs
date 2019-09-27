using System;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input="")
        {
            if (string.IsNullOrEmpty(input)) return 0;
            int sum = 0;
            var numbers = input.Split(new [] {",", "\n"}, StringSplitOptions.None);
            foreach (var number in numbers)
            {
                sum += int.Parse(number);
            }
            return sum;
        }
    }
}