Kata: Testing 1-2-3
Link: https://www.codewars.com/kata/54bf85e3d5b56c7a05000cf9

// Your team is writing a fancy new text editor and you've been tasked with implementing the line numbering.

// Write a function which takes a list of strings and returns each line prepended by the correct number.

// The numbering starts at 1. The format is n: string. Notice the colon and space in between.

// Examples:

// number(List<string>()) // => List<string>()
// number(List<string>{"a", "b", "c"}) // => ["1: a", "2: b", "3: c"]

using System;
using System.Collections.Generic;

public class LineNumbering 
{
    public static List<string> Number(List<string> lines) 
    {
        for (int i = 0; i < lines.Count; ++i) {
          lines[i] = String.Format("{0}: {1}",i+1,lines[i]);
        }
        return lines;
    }
}