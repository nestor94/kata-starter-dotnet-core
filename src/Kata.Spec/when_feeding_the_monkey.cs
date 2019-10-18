﻿using System;
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

    public class when_user_input_is_an_empty_string
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_inputs_a_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3"); };

        It should_return_that_number = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_has_two_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3,4"); };

        It should_return_the_sum = () => { _result.Should().Be(7); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_inputs_multiple_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };

        It should_sum_them_all = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_using_new_line_as_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1\n2,3"); };

        It should_return_the_sum = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_inputs_custom_separator
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };

        It should_sum_the_input = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_contains_one_negative
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2")); };

        It should_throw_an_exception_with_that_negative = () => { _result.Message.Should().Be("negatives not allowed: -2"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_user_input_contains_multiple_negatives
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2,-3")); };

        It should_throw_an_exception_will_all_the_negative_numbers = () => { _result.Message.Should().Be("negatives not allowed: -2, -3"); };
        static Exception _result;
        private static Calculator _systemUnderTest;
    }

    public class when_user_input_has_number_larger_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,1000,1001"); };

        It should_sum_only_number_less_than_1001 = () => { _result.Should().Be(1003); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_inputs_multichar_custom_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };

        It should_sum_them_all = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_using_several_multi_character_delimiters
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[*][%]\n1*2%3"); };

        It should_return_the_sum = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }
    
}

/*
11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)
*/