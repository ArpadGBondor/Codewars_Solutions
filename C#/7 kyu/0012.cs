// Kata: Special Number (Special Numbers Series #5)
// Link: https://www.codewars.com/kata/5a55f04be6be383a50000187

// Notes
// The number passed will be positive (N > 0)

// All single-digit numbers within the interval [1:5] are considered special
// numbers

// Examples
// 2 ==> return "Special!!"
// Explanation: It's a single-digit number within the interval [1:5]

// 9 ==> return "NOT!!"
// Explanation: Although, it's a single-digit number but Outside the interval
// [1:5]


// 23 ==> return "Special!!"
// Explanation: All the number's digits formed from the interval [0:5] digits

// 39 ==> return "NOT!!"
// Explanation: Although there is a digit (3) within the interval,
//              the second digit is not (Must be ALL the number's Digits)

// 59 ==> return "NOT!!"
// Explanation: Although there is a digit (5) within the interval,
//              the second digit is not (Must be ALL the number's Digits)

// 513 ==> return "Special!!"

// 709 ==> return "NOT!!"
// For More Enjoyable Katas
// ALL translation are welcomed

// Enjoy Learning !!

// Zizou

using System;
using System.Text.RegularExpressions;

class Kata
{
    private static readonly Regex SpecialNumberPattern = new Regex("^[0-5]*$");

    public static string SpecialNumber(int number)
    {
        return SpecialNumberPattern.IsMatch(number.ToString()) ? "Special!!" : "NOT!!";
    }
}