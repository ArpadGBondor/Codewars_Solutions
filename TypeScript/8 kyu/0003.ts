// Kata: Playing with cubes II
// Link: https://www.codewars.com/kata/55c0ac142326fdf18d0000af

// Hey Codewarrior!

// You already implemented a Cube class, but now we need your help again! I'm
// talking about constructors. We don't have one. Let's code one (or more) such
// that one can instantiate an object via it, handling either no arguments or a
// single integer.

// Also we got a problem with negative values. Correct the code so negative
// values will be switched to positive ones!

// The constructor taking no arguments should assign 0 to Cube's Side property.

export class Cube {
  private _side: number;

  constructor(value: number = 0) {
    this._side = Math.abs(value);
  }

  public getSide(): number {
    return this._side;
  }

  public setSide(value: number) {
    this._side = Math.abs(value);
  }
}
