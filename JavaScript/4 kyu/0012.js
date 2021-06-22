// Kata: Minimum Number of Coins
// Link: https://www.codewars.com/kata/557f138eb472f5caa7000062

// You have to write a function that gets an input as either a string or a number and returns the minimum number of coins required to make such an amount.

// You have to use British currency, considering only the broadly used coins, that is pound coins (1£ and 2£) and penny coins (50p, 20p, 10p, 5p, 2p, 1p).

// Image: http://www.cppravia.es/archivos/triskel_talleres/5/2013-2014/coins_uk_2.png

// Rules for the input you will get:

// Currency is going to be given, if in string format, with a certain English format: the "£" symbol may come first (and in this case assume that the value is in pounds), the "p" symbol may come last - any other position for them is just wrong; if an integer with no symbols is given, assume it is a value in pennies; if a float with no symbol is given, assume it is a value in pounds and round it to the second decimal (ie: do not count fractions of pennies: 1.257422457p==1.26p).

// To make it even more clear: if the input starts with a pound symbol ("£" in most languages, "L" in Ruby unless I can get to make it display UFT-8 chars) or if the number is a float, the value is in pounds, otherwise consider it as pennies.

// Expected output format:

// Output has to be formatted in decreasing weight/nominal value of coins, with the last two elements (if two or more) separated by and "and", the rest separeted by commas and the correct plurals, like this:

// minCoins("4p") == "2 2p coins"
// minCoins("11p") == "1 10p coin and 1 1p coin"
// minCoins(456) == "2 £2 coins, 1 50p coin, 1 5p coin and 1 1p coin"
// If an input is invalid for any reason (invalid characters, misplaced characters, negative numbers and so on), considering it equivalent to 0 pennies, so you have to return a null/None/nil value.

// minCoins("L200") == "Invalid input - enter a positive amount of money"
// minCoins("2£1p") == "Invalid input - enter a positive amount of money"
// minCoins("54pp") == "Invalid input - enter a positive amount of money"
// minCoins("-21p") == "Invalid input - enter a positive amount of money"
// minCoins("£21£") == "Invalid input - enter a positive amount of money"
// minCoins("4.2.") == "Invalid input - enter a positive amount of money"
// minCoins("2£0p") == "Invalid input - enter a positive amount of money"
// Be ready for A LOT of edge cases to test this last condition.

// Notes and tips: particularly for beginners, be sure that you understand fully well the problem; if I may advice, don't take the problem as a whole, but split it into lesser problems and then solve them progressively, putting together the solution (an approach that it is called divide-and-conquer in computer science).

// You will need at least 3 main parts and you may think of creating 3 different support functions for each task instead of using a massive bloated function to solve it all.

// You will need to:

// parse the given input, filtering out invalid strings and taking into account if the figures are in pound or pennis;
// translate it all into the lesser number of coins you can use;
// create a reply string and return it.
// Part I could be the more difficult if you are not familiar with regexes: if this is the case, read carefully my description of the format above and try to tranlate it into a regex - feel free to ask in the comment if you need some help or tip for learning them!

// Part II is relatively easy once you figure out how you could have the least possible amount of coins.

// Parte III maybe tricky, particularly for edge cases, but if you work well in the previous parts, you should be able to handle it.

// Note on currency: I was given most of the test cases by a British man, so I assume most of them make some sense, despite being rather "edgy"; if they don't, just pretend they do for practice's sake :D.

function minCoins(amount){
    //   console.log(amount);
      let pennies = 0;
      
      if (typeof (amount) === "string") {
        if (!amount.match(/^£?([0-9]+\.?)?[0-9]+p?$/))
          return "Invalid input - enter a positive amount of money";
        
        // if the string starts with £ or the number is float
        if (amount.match(/^£/) || amount.match(/\./)) {
          let number = amount;
          // remove £
          if (amount.match(/^£/)) {
            number = number.substr(1);
          }
          // remove p
          if (amount.match(/p$/)) {
            number = number.substr(0,number.length-1)
          }
          // parseFloat * 100 => pennies
          pennies = Math.round(parseFloat(number) * 100);
        } else {
          let number = amount;
          // remove p
          if (amount.match(/p$/)) {
            number = number.substr(0,number.length-1)
          }
          // parseInt => pennies
          pennies = parseInt(number);
        }
      } else {
        pennies = amount;
      }
      
      let coinCount =   [0   ,0   ,0    ,0    ,0    ,0   ,0   ,0   ];
      const coinName =  ["£2","£1","50p","20p","10p","5p","2p","1p"];
      const coinValue = [200 ,100 ,50   ,20   ,10   ,5   ,2   ,1   ];
      let result = "";
      for (let i =0; i < coinCount.length; ++i){
        coinCount[i] = Math.floor(pennies/coinValue[i]);
        pennies -= coinValue[i] * coinCount[i];
      }
      for (let i =0; i < coinCount.length; ++i){
        if (coinCount[i] > 0) {
          if (result) {
            let last = true;
            for (let j = i+1; j < coinCount.length; ++j)
              if (coinCount[j] > 0)
                last = false;
            if (last) {
              result += " and ";
            } else {
              result += ", ";
            }
          }
            
          result += `${coinCount[i]} ${coinName[i]} coin${coinCount[i] > 1 ? "s" : ""}`;
        }
      }
      
      return result;
    }