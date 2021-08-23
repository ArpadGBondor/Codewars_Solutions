// Kata: Vasya - Clerk
// Link: https://www.codewars.com/kata/555615a77ebc7c2c8a0000b8

// The new "Avengers" movie has just been released! There are a lot of people at the cinema box office standing in a huge line. Each of them has a single 100, 50 or 25 dollar bill. An "Avengers" ticket costs 25 dollars.

// Vasya is currently working as a clerk. He wants to sell a ticket to every single person in this line.

// Can Vasya sell a ticket to every person and give change if he initially has no money and sells the tickets strictly in the order people queue?

// Return YES, if Vasya can sell a ticket to every person and give change with the bills he has at hand at that moment. Otherwise return NO.

// Examples:
// tickets([25, 25, 50]) // => YES
// tickets([25, 100]) // => NO. Vasya will not have enough money to give change to 100 dollars
// tickets([25, 25, 50, 50, 100]) // => NO. Vasya will not have the right bills to give 75 dollars of change (you can't make two bills of 25 from one of 50)

function tickets(peopleInLine) {
  cassa = {
    25: 0,
    50: 0,
    100: 0,
  };
  notes = [100, 50, 25];

  for (let i = 0; i < peopleInLine.length; ++i) {
    let payment = peopleInLine[i];
    console.log('Before');
    console.log(cassa);
    console.log(payment);
    // add note to the cassa
    ++cassa[`${payment}`];
    // take off price of the ticket
    payment -= 25;
    // Starting from the biggest notes, check cassa for change
    notes.forEach((note) => {
      while (note <= payment && cassa[`${note}`] > 0) {
        --cassa[`${note}`];
        payment -= note;
      }
    });
    console.log('After');
    console.log(cassa);
    console.log(payment);

    // If we didn't have enough change, return "NO"
    if (payment > 0) return 'NO';
  }
  // If everything went good, return "Yes"
  return 'YES';
}
