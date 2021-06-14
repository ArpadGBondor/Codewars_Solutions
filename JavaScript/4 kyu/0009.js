// Kata: Lambda term reduction
// Link: https://www.codewars.com/kata/55f307bef98d9c4adc000006

// Implement a lambda function which takes a string (a lambda expression in RPN) and returns an object representation for that input string.

// There are three different types of lambda terms:

// A variable: It is specified by its name. Just like a variable in JavaScript. E.g. the RPN string x defines a variable with name x.
// An abstraction λ: Combines a variable input and another lambda term as function body. E.g. the RPN string x y λ defines an abstraction and has the same meaning as the anonymous function x => y in JavaScript.
// An application @: Combines two lambda terms. E.g. the RPN string f x @ has the same meaning as the function application f(x) in JavaScript.
// The object returned by the lambda function should have the following methods:

// toString(): Should return the same RPN string as given to the lambda function.
// free(): Should return an array of the names of all free variables in the lambda term. The array can have arbitrary order but should hold no duplicates.
// A single variable is always free.
// Free variables of an abstraction are the free variables of the body without the input variable.
// Free variables of an application are the union of the free variables of both lambda terms.
// bound(): Should return an array of the names of all bound variables in the lambda term. The array can have arbitrary order but should hold no duplicates.
// A single variable is never bound.
// Bound variables of an abstraction are the union of the input variable name and the bound variables of the body.
// Bound variables of an application are the union of the bound variables of both lambda terms.
// reduce(): Return a lambda object which is reduced (β-reduction):
// A variable cannot be reduced further.
// An abstraction is reduced to an abstraction with the same input but with reduced body.
// An application is reduced like this:
// Reduce both child lambda terms.
// If the reduced left side is an abstraction, substitute every occurrence of the input variable of the abstraction in its body with the reduced right side of the application, and reduce again.
// Otherwise, just apply the reduced terms to each other.
// examples:
//   x                 ->  x
//   x y λ             ->  x y λ
//   f x @             ->  f x @
//   x x λ y @         ->  y
//   x x x @ λ y @     ->  y y @
//   x x x x @ λ λ y @ ->  x x x @ λ

class Lambda {
  constructor(expr) {
    // recursive function to process the graph
    const readExpression = (e) => {
      if (e[e.length - 1] === 'λ') {
        const abstraction = e.pop();
        const term = readExpression(e);
        const input = readExpression(e);
        return [input, term, abstraction];
      } else if (e[e.length - 1] === '@') {
        const application = e.pop();
        const term1 = readExpression(e);
        const term2 = readExpression(e);
        return [term2, term1, application];
      } else return [e.pop()];
    };

    // store the expression as a graph.
    this.expression = readExpression(expr.split(' '));
  }
  arrayToString(e) {
    if (typeof e === 'object') {
      let temp = [];
      for (let i = 0; i < e.length; ++i) {
        if (typeof e[i] === 'object') {
          temp.push(this.arrayToString(e[i]));
        } else {
          temp.push(e[i]);
        }
      }
      return temp.join(' ');
    } else return e.toString();
  }
  toString() {
    return this.arrayToString(this.expression);
  }

  free() {
    // recursive function to process the graph
    const freeVariables = (e) => {
      // e contains a variable
      if (e.length < 2) {
        return [...e];
        // e contains abstraction
      } else if (e[2] === 'λ') {
        // all variables
        const free = freeVariables(e[1]);
        // remove imput variable
        let inputIndex = free.indexOf(e[0][0]);
        while (inputIndex > -1) {
          free.splice(inputIndex, 1);
          inputIndex = free.indexOf(e[0][0]);
        }
        return free;
        // e contains application
      } else {
        // filter out the duplicates
        const leftSide = freeVariables(e[0]);
        const rightSide = freeVariables(e[1]);
        rightSide.forEach((variable) => {
          if (!leftSide.includes(variable)) leftSide.push(variable);
        });
        return leftSide;
      }
    };
    return freeVariables(this.expression);
  }

  bound() {
    // recursive function to process the graph
    const boundVariables = (e) => {
      // e contains a variable
      if (e.length < 2) {
        return [];
        // e contains abstraction
      } else if (e[2] === 'λ') {
        // filter out the duplicates
        const leftSide = [...e[0]];
        const rightSide = boundVariables(e[1]);
        rightSide.forEach((variable) => {
          if (!leftSide.includes(variable)) leftSide.push(variable);
        });
        return leftSide;
        // e contains application
      } else {
        // filter out the duplicates
        const leftSide = boundVariables(e[0]);
        const rightSide = boundVariables(e[1]);
        rightSide.forEach((variable) => {
          if (!leftSide.includes(variable)) leftSide.push(variable);
        });
        return leftSide;
      }
    };
    return boundVariables(this.expression);
  }

  reduce() {
    // recursive function to process the graph
    const reduceExpression = (e, substitute = []) => {
      // e contains a variable
      if (e.length < 2) {
        for (let i = 0; i < substitute.length; ++i) {
          if (substitute[i][0] === e[0])
            // The only reason to call the function again,
            // is to get a copy of the substitute element (in case it's a complex structure)
            return reduceExpression(substitute[i][1]);
        }
        return [e[0]];
        // e contains abstraction
      } else if (e[2] === 'λ') {
        let i = 0;
        while (i < substitute.length) {
          if (e[0][0] === substitute[i][0]) {
            substitute.splice(i, 1);
          } else {
            ++i;
          }
        }
        return [[e[0][0]], reduceExpression(e[1], substitute), e[2]];
        // e contains application
      } else {
        const left = reduceExpression(e[0], substitute);
        const right = reduceExpression(e[1], substitute);
        // if left is an abstraction => reduce
        if (left[2] === 'λ') {
          return reduceExpression(left[1], [...substitute, [left[0][0], right]]);
        } else {
          return [left, right, e[2]];
        }
      }
    };
    return this.arrayToString(reduceExpression(this.expression));
  }
}

function lambda(expr) {
  const result = new Lambda(expr);
  return result;
}
