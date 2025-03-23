// Kata: Simple Fun #161: Replace Dashes As One
// Link: https://www.codewars.com/kata/58af9f7320a9ecedb30000f1

// Task
// If string has more than one neighboring dashes(e.g. --) replace they with one
// dash(-).

// Dashes are considered neighbors even if there is some whitespace between them.

// Example
// For str = "we-are- - - code----warriors.-"

// The result should be "we-are- code-warriors.-"

// Input/Output
// [input] string str

// [output] a string

namespace myjinxin
{
using System;
using System.Text.RegularExpressions;
    
    public class Kata
    {
        public string ReplaceDashesAsOne(string str){
          return Regex.Replace(str, @"-+(\s+-+)*", "-");
        }
    }
}