// Kata: Name Array Capping
// Link: https://www.codewars.com/kata/5356ad2cbb858025d800111d

// Create a method that accepts an array of names, and returns an array of each
// name with its first letter capitalized.

// example

// Kata.CapMe(new string[] {"jo", "nelson", "jurie"})     
//    => new string[] {"Jo", "Nelson", "Jurie"}
// Kata.CapMe(new string[] {"KARLY", "DANIEL", "KELSEY"}) 
//    => new string[] {"Karly", "Daniel", "Kelsey"}

using System;
using System.Linq;

public static class Kata
{
  public static string[] CapMe(string[] strings)
  {
    return strings.Select((string name)=>(char.ToUpper(name[0])+name.Substring(1).ToLower())).ToArray();
  }
}