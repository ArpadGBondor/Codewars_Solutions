// Kata: 7-segment converter
// Link: https://www.codewars.com/kata/52a7099f8a4d9604bb000472

// A 7-segment converter is basically a fancy way of saying a component that turns a number into instructions for a digital clock display.

// For this kata, you need to write a function, sevenSegmentNumber(number), that returns the correct binary input for the display.

// The display has 7 segments that look like this:

//  _ 
// |_|
// | |
//  ¯ 
// Each segment is turned on or off to form a number from 0 to 9. The instruction it takes is in the form of a single binary stream that looks something like this: 1011010. Each bit tells the display if the corresponding segment should be on or off.

// The bits for each segment are in the following order, from right to left: (Binary always reads from right to left!)

// Top Horizontal
// Middle Horizontal
// Bottom Horizontal
// Top-Left Vertical
// Top-Right Vertical
// Bottom-Left Vertical
// Bottom-Right Vertical
// So the example instruction above, 1011010 would result in the display only showing the middle, top-left, top-right, and bottom-right segments, forming the shape of a 4. That means that, for the number 4, your function should return 90, which has exactly the same binary representation: 1011010.

// If you can do this for each of the other 9 digits, you'll pass the test!

// (You should also throw an error if the number passed to the function is not valid, and not a single-digit number.)

// I have included a helper function, display(input) which will return some HTML for you to log out to the console, which will show you how the given number input would displayed.

// Here's each digit, shown as it should be implemented:

//  _ 
// | |
// | |
//  ¯ 

//   |
//   |

//  _ 
//  _|
// |  
//  ¯ 
//  _ 
//  _|
//   |
//  ¯ 
    
// |_|
//   |
   
//  _ 
// |_ 
//   |
//  ¯ 
//  _ 
// |_ 
// | |
//  ¯ 
//  _ 
//   |
//   |
   
//  _ 
// |_|
// | |
//  ¯ 
//  _ 
// |_|
//   |
//  ¯ 

// Eratta
// Currently the C# tests will only accept thrown Exception objects for errors.

// Solution:
using System;

public class Kata
{
  public static int SevenSegmentNumber(int number) 
  {
    // I tried following TDD, created tests for each bit and invalid input, and passed the tests one by one
    if (number > 9 || 0 > number) throw new Exception();
    int result = 0;
    // Top Horizontal
    int digit = 0;
    if (number != 1 && number != 4)
      result += (int) Math.Pow(2,digit);
    // Middle Horizontal
    ++digit;
    if (number > 1 && number != 7)
      result += (int) Math.Pow(2,digit);
    // Bottom Horizontal
    ++digit;
    if (number != 1 && number != 4 && number != 7)
      result += (int) Math.Pow(2,digit);
    // Top-Left Vertical
    ++digit;
    if (number == 0 || (4 <= number && number <= 6) || 8 <= number)
      result += (int) Math.Pow(2,digit);
    // Top-Right Vertical
    ++digit;
    if (number <= 4 || 7 <= number)
      result += (int) Math.Pow(2,digit);
    // Bottom-Left Vertical
    ++digit;
    if (number % 2 == 0 && 4 != number)
      result += (int) Math.Pow(2,digit);
    // Bottom-Right Vertical
    ++digit;
    if (number != 2)
      result += (int) Math.Pow(2,digit);
    Console.WriteLine($"input: {number}, result: {result}");
    return result;
  }  
}

// Tests:
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void Bit1()
    {
      Assert.AreEqual(1, Kata.SevenSegmentNumber(0) % 2,"Wrong bit on input: 0");
      Assert.AreEqual(0, Kata.SevenSegmentNumber(1) % 2,"Wrong bit on input: 1");
      Assert.AreEqual(1, Kata.SevenSegmentNumber(2) % 2,"Wrong bit on input: 2");
      Assert.AreEqual(1, Kata.SevenSegmentNumber(3) % 2,"Wrong bit on input: 3");
      Assert.AreEqual(0, Kata.SevenSegmentNumber(4) % 2,"Wrong bit on input: 4");
      Assert.AreEqual(1, Kata.SevenSegmentNumber(5) % 2,"Wrong bit on input: 5");
      Assert.AreEqual(1, Kata.SevenSegmentNumber(6) % 2,"Wrong bit on input: 6");
      Assert.AreEqual(1, Kata.SevenSegmentNumber(7) % 2,"Wrong bit on input: 7");
      Assert.AreEqual(1, Kata.SevenSegmentNumber(8) % 2,"Wrong bit on input: 8");
      Assert.AreEqual(1, Kata.SevenSegmentNumber(9) % 2,"Wrong bit on input: 9");
    }

    [Test]
    public void Bit2()
    {
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(0) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 0");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(1) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 1");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(2) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 2");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(3) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 3");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(4) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 4");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(5) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 5");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(6) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 6");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(7) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 7");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(8) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 8");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(9) / (int) Math.Pow(2,1)) % 2,"Wrong bit on input: 9");
    }

    [Test]
    public void Bit3()
    {
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(0) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 0");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(1) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 1");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(2) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 2");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(3) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 3");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(4) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 4");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(5) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 5");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(6) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 6");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(7) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 7");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(8) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 8");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(9) / (int) Math.Pow(2,2)) % 2,"Wrong bit on input: 9");
    }

    [Test]
    public void Bit4()
    {
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(0) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 0");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(1) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 1");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(2) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 2");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(3) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 3");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(4) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 4");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(5) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 5");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(6) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 6");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(7) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 7");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(8) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 8");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(9) / (int) Math.Pow(2,3)) % 2,"Wrong bit on input: 9");
    }

    [Test]
    public void Bit5()
    {
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(0) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 0");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(1) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 1");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(2) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 2");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(3) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 3");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(4) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 4");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(5) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 5");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(6) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 6");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(7) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 7");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(8) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 8");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(9) / (int) Math.Pow(2,4)) % 2,"Wrong bit on input: 9");
    }

    [Test]
    public void Bit6()
    {
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(0) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 0");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(1) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 1");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(2) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 2");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(3) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 3");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(4) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 4");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(5) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 5");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(6) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 6");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(7) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 7");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(8) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 8");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(9) / (int) Math.Pow(2,5)) % 2,"Wrong bit on input: 9");
    }

    [Test]
    public void Bit7()
    {
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(0) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 0");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(1) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 1");
      Assert.AreEqual(0, (Kata.SevenSegmentNumber(2) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 2");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(3) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 3");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(4) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 4");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(5) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 5");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(6) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 6");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(7) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 7");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(8) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 8");
      Assert.AreEqual(1, (Kata.SevenSegmentNumber(9) / (int) Math.Pow(2,6)) % 2,"Wrong bit on input: 9");
    }
    
    [Test]
    public void InvalidInput()
    {
      Assert.Throws<Exception>(()=>Kata.SevenSegmentNumber(-1));
      Assert.Throws<Exception>(()=>Kata.SevenSegmentNumber(-100));
      Assert.Throws<Exception>(()=>Kata.SevenSegmentNumber(10));
      Assert.Throws<Exception>(()=>Kata.SevenSegmentNumber(1000));
    }
    
  }
}
