using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;

        Establish context = () =>
            _systemUnderTest = new Monkey();

        Because of = () =>
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }

    public class when_user_input_is_empty
    {
        private Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_a_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3"); };

        It should_return_the_inout = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_two_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3,4"); };

        It should_return_the_sum_of_those_numbers = () => { _result.Should().Be(7); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_unknown_length
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };

        It should_sum_those_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_there_is_other_delimiter__as_newline
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1\n2,3"); };

        It should_sum_those_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_defines_a_custom_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };

        It should_split_by_that_delimiter_and_return_the_sum = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_inputs_negative_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-5,8")); };

        It should_throw_an_exception = () => { _result.Message.Should().Be("negatives not allowed: -5"); };
        static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_user_input_contains_multiple_negative_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-5,-8")); };

        It should_throw_an_Exception_listing_all_negatives = () => { _result.Message.Should().Be("negatives not allowed: -5, -8"); };
        private static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_user_inputs_numbers_greater_than_1001
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("2,1001"); };

        It should_ignore_them = () => { _result.Should().Be(2); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_when_input_configures_a_multicharacter_custom_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };

        It should_split_by_that_delimiter_and_return_the_sum = () => { _result.Should().Be(6); };
        
        private static Calculator _systemUnderTest;
        private static int _result;
    }


}

/*
10. Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[***]\n1***2***3” should return 6)
11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)
*/