// Kata: ⚠️Fusion Chamber Shutdown⚠️
// Link: https://www.codewars.com/kata/5fde1ea66ba4060008ea5bd9

// A laboratory is testing how atoms react in ionic state during nuclear fusion.
// They introduce different elements with Hydrogen in high temperature and
// pressurized chamber. Due to unknown reason the chamber lost its power and the
// elements in it started precipitating

// Given the number of atoms of Carbon [C],Hydrogen[H] and Oxygen[O] in the
// chamber. Calculate how many molecules of Water [H2O], Carbon Dioxide [CO2]
// and Methane [CH4] will be produced following the order of reaction affinity
// below

// 1. Hydrogen reacts with Oxygen   = H2O
// 2. Carbon   reacts with Oxygen   = CO2
// 3. Carbon   reacts with Hydrogen = CH4

// FOR EXAMPLE:
// (C,H,O) = (45,11,100)
// return no. of water, carbon dioxide and methane molecules
// Output should be like:
// (5,45,0)

using System;

public class Kata {
  public static (int, int, int) Burner(int c, int h, int o) {
    
    // Based on tests it seems that water always takes priority
    int water = Math.Min(h/2,o);
    h -= 2*water;
    o -= water;
    
    // Based on tests CO2 is next priority
    int co2 = Math.Min(c,o/2);
    c -= co2;
    o -= 2*co2;
    
    // Based on tests methane only forms from lefovers
    int methane = Math.Min(c,h/4);
        
    return (water, co2, methane);
  }
}