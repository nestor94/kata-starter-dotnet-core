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

            int sum = 0;
            var numbers = input.Split(",");
            if (numbers.Length > 1)
            {
                sum = int.Parse(numbers[0]) + int.Parse((numbers[1]));
                return sum;
            }

            return int.Parse(input);

        }
    }
}