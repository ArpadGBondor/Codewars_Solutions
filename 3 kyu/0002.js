// Kata: Calculator
// Link: https://www.codewars.com/kata/5235c913397cbf2508000048

// Create a simple calculator that given a string of operators (), +, -, *, / and numbers separated by spaces returns the value of that expression

// Example:

// Calculator().evaluate("2 / 2 + 3 * 4 - 6") # => 7
// Remember about the order of operations! Multiplications and divisions have a higher priority and should be performed left-to-right. Additions and subtractions have a lower priority and should also be performed left-to-right.

const Calculator = function () {
  this.executeOperation = (string, operatorIndex) => {
    const operation = {
      '+': (a, b) => a + b,
      '-': (a, b) => a - b,
      '*': (a, b) => a * b,
      '/': (a, b) => a / b,
    };
    // solve the left and the right side recursively
    let leftOperand = this.evaluate(string.substr(0, operatorIndex)),
      rightOperand = this.evaluate(string.substr(operatorIndex + 1)),
      operator = string[operatorIndex];
    // execute the operator between the sides
    console.log(`${string} => ${operation[operator](leftOperand, rightOperand)}`);
    return operation[operator](leftOperand, rightOperand);
  };

  this.evaluate = (string) => {
    // Handle all parenthesis first
    let openingParenthesis = string.indexOf('(');
    while (openingParenthesis > -1) {
      // Find the closing pair of the opening parenthesis
      let closingParenthesis = openingParenthesis + 1,
        numberOfOpeningParenthesis = 1;
      while (string[closingParenthesis] !== ')' || numberOfOpeningParenthesis > 1) {
        if (string[closingParenthesis] === '(') ++numberOfOpeningParenthesis;
        if (string[closingParenthesis] === ')') --numberOfOpeningParenthesis;
        ++closingParenthesis;
      }
      // Solve the section between the opening and closing parenthesis recursively
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
      return this.executeOperation(string, additionOperator);
    } else {
      // if there's no addition operator, check for  multiplication and division
      // Find the last multiplication operator
      let multiplicationOperator = Math.max(string.lastIndexOf('*'), string.lastIndexOf('/'));
      if (multiplicationOperator > -1) {
        return this.executeOperation(string, multiplicationOperator);
      } else {
        // if there are no operators, just return the value
        console.log(`${string} => ${parseFloat(string)}`);
        return parseFloat(string);
      }
    }
  };
};
