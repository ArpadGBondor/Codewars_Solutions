// Kata: Calculator
// Link: https://www.codewars.com/kata/5235c913397cbf2508000048

// Create a simple calculator that given a string of operators (), +, -, *, / and numbers separated by spaces returns the value of that expression

// Example:

// Calculator().evaluate("2 / 2 + 3 * 4 - 6") # => 7
// Remember about the order of operations! Multiplications and divisions have a higher priority and should be performed left-to-right. Additions and subtractions have a lower priority and should also be performed left-to-right.

const Calculator = function () {
  this.evaluate = (string) => {
    // Handle all parenthesis first
    let openingParenthesis = string.indexOf('(');
    while (openingParenthesis > -1) {
      // Find the pair of the opening parenthesis
      let closingParenthesis = openingParenthesis + 1,
        numberOfOpeningParenthesis = 1;
      while (string[closingParenthesis] !== ')' || numberOfOpeningParenthesis > 1) {
        if (string[closingParenthesis] === '(') ++numberOfOpeningParenthesis;
        if (string[closingParenthesis] === ')') --numberOfOpeningParenthesis;
        ++closingParenthesis;
      }
      // Solve the section between the parenthesis recursively
      string =
        string.substr(0, openingParenthesis) +
        `${this.evaluate(string.substr(openingParenthesis + 1, closingParenthesis - openingParenthesis - 1))}` +
        string.substr(closingParenthesis + 1);
      // Check if we have more opening parenthesis
      openingParenthesis = string.indexOf('(');
    }

    // Additions and subtractions
    // Find the last addition operator
    // check for extra space at subtractions, to avoid confusion with negative numbers
    let additionOperator = Math.max(string.lastIndexOf('+'), string.lastIndexOf('- '));
    if (additionOperator > -1) {
      // solve the left and the right side recursively
      let leftOperand = this.evaluate(string.substr(0, additionOperator)),
        rightOperand = this.evaluate(string.substr(additionOperator + 1));
      // execute the operator between the sides
      if (string[additionOperator] === '+') {
        console.log(`${string} => ${leftOperand + rightOperand}`);
        return leftOperand + rightOperand;
      } else {
        console.log(`${string} => ${leftOperand - rightOperand}`);
        return leftOperand - rightOperand;
      }
    } else {
      // if there's no addition operator, check for  multiplication and division
      // Find the last addition operator
      let multiplicationOperator = Math.max(string.lastIndexOf('*'), string.lastIndexOf('/'));
      if (multiplicationOperator > -1) {
        // solve the left and the right side recursively
        let leftOperand = this.evaluate(string.substr(0, multiplicationOperator)),
          rightOperand = this.evaluate(string.substr(multiplicationOperator + 1));
        // execute the operator between the sides
        if (string[multiplicationOperator] === '*') {
          console.log(`${string} => ${leftOperand * rightOperand}`);
          return leftOperand * rightOperand;
        } else {
          console.log(`${string} => ${leftOperand / rightOperand}`);
          return leftOperand / rightOperand;
        }
      } else {
        // if there are no operators, just return the value
        console.log(`${string} => ${parseFloat(string)}`);
        return parseFloat(string);
      }
    }
  };
};
