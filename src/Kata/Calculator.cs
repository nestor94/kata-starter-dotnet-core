namespace Kata
{
    public class Calculator
    {
        public int Add(string input="")
        {
            if (string.IsNullOrEmpty(input)) return 0;
            int sum = 0;
            var numbers = input.Split(",");
            foreach (var number in numbers)
            {
                sum += int.Parse(number);
            }
            return sum;
        }
    }
}