// Kata: Vector class
// Link: https://www.codewars.com/kata/526dad7f8c0eb5c4640000a4

// Create a Vector object that supports addition, subtraction, dot products, and
// norms. So, for example:

// a = new Vector([1, 2, 3])
// b = new Vector([3, 4, 5])
// c = new Vector([5, 6, 7, 8])

// a.add(b)      # should return a new Vector([4, 6, 8])
// a.subtract(b) # should return a new Vector([-2, -2, -2])
// a.dot(b)      # should return 1*3 + 2*4 + 3*5 = 26
// a.norm()      # should return sqrt(1^2 + 2^2 + 3^2) = sqrt(14)
// a.add(c)      # throws an error

// If you try to add, subtract, or dot two vectors with different lengths, you
// must throw an error!

// Also provide:

//    a toString method, so that using the vectors from above, a.toString() ===
//    '(1,2,3)' (in Python, this is a __str__ method, so that str(a) ==
//    '(1,2,3)'. In PHP, this is __toString magic method)

//    an equals method, to check that two vectors that have the same components
//    are equal

// Note: the test cases will utilize the user-provided equals method.

export class Vector {
  vector: number[] = [];

  constructor(components: number[]) {
    this.vector = [...components];
  }

  equals(v2: Vector): boolean {
    if (this.vector.length !== v2.vector.length) return false;
    return this.vector
      .map((n: number, i: number): boolean => n === v2.vector[i])
      .reduce((sum: boolean, current: boolean) => sum && current, true);
  }

  add(v2: Vector): Vector {
    if (this.vector.length !== v2.vector.length)
      throw new Error('Wrong vector size!');
    return new Vector(
      this.vector.map((n: number, i: number) => n + v2.vector[i])
    );
  }

  subtract(v2: Vector): Vector {
    if (this.vector.length !== v2.vector.length)
      throw new Error('Wrong vector size!');
    return new Vector(
      this.vector.map((n: number, i: number) => n - v2.vector[i])
    );
  }

  dot(v2: Vector): number {
    if (this.vector.length !== v2.vector.length)
      throw new Error('Wrong vector size!');
    return this.vector
      .map((n: number, i: number) => n * v2.vector[i])
      .reduce((sum: number, current: number) => sum + current, 0);
  }

  norm() {
    return Math.sqrt(
      this.vector.reduce(
        (sum: number, current: number) => sum + current ** 2,
        0
      )
    );
  }

  toString() {
    return `(${this.vector.map((n: number) => n.toString()).join(',')})`;
  }
}
