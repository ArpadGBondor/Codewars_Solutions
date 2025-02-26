// Kata: Thinking & Testing : Not perfect? Throw away!
// Link: https://www.codewars.com/kata/56dae2913cb6f5d428000f77

// No Story

// No Description

// Only by Thinking and Testing

// Look at the results of the testcases, and guess the code!

// TEST CASES:
// //In life, we have to choose to keep some things,
// //and give up something at the same time.
// Assert.That(kata.Testit(""), Is.EqualTo(""));
// Assert.That(kata.Testit("0"), Is.EqualTo(""));
// Assert.That(kata.Testit("00"), Is.EqualTo(""));
// Assert.That(kata.Testit("001"), Is.EqualTo("1"));
// Assert.That(kata.Testit("0011"), Is.EqualTo("11"));
// Assert.That(kata.Testit("00111"), Is.EqualTo("11"));
// Assert.That(kata.Testit("001111"), Is.EqualTo("111"));
// Assert.That(kata.Testit("0011111"), Is.EqualTo("111"));
// Assert.That(kata.Testit("00111111"), Is.EqualTo("1111"));
// Assert.That(kata.Testit("00aaaaaa"), Is.EqualTo("aaaa"));
// Assert.That(kata.Testit("00ababab"), Is.EqualTo("abbb"));
// //click "Submit" try more testcase...

// Assert.That(kata.Testit("H7gM%&H,e2~m83_^6"), Is.EqualTo("gM&,m3"));
// Assert.That(kata.Testit("!`KDQh"), Is.EqualTo("KDh"));
// Assert.That(kata.Testit("(9j7"), Is.EqualTo("j7"));
// Assert.That(kata.Testit("1Y}R~~z"), Is.EqualTo("}R~"));
// Assert.That(kata.Testit("nHSy6ck83[p^Key]Snh"), Is.EqualTo("Syc8^en"));
// Assert.That(kata.Testit("5Sca|vUguzU.Cx7 c;"), Is.EqualTo("cavg.x;"));

// Conclusion: 2nd,3rd,5th,7th,11th,13th character of the string remains

using System.Linq;

namespace myjinxin
{
    using System;
    
    public class Kata
    {
        public string Testit(string s) {
          int n = s.Length;
          
          bool[] isPrime = new bool[n];
          
          for (int i = 2; i<n; ++i)
            isPrime[i] = true;
          
          for (int i = 2; i<n; ++i) {
            if (isPrime[i]) {
              for (int j = i*2; j < n; j += i) {
                isPrime[j] = false;
              }
            }
          }
          
          return String.Concat(s.Where((c,index)=>(isPrime[index])));
        }
    }
}