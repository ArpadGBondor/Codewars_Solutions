// Kata: Binary Genetic Algorithms
// Link: https://www.codewars.com/kata/526f35b9c103314662000007

// Explanation of the concept
// Genetic algorithms are a useful tool for machine learning. One simple way to find a solution to a problem that would
// typically be too difficult to brute force is through algorithms such as these.

// For example, say our problem is, given the list [1,2,3,4,5,6,7,8,9,10], find a way to partition the list into two lists
// such that the sum of one list is 38 and the product of the other list is 210. You could of course brute force it, using
// the fact that you can find the divisors of 210. But say you have the list of numbers from 1 to 50! That makes it a lot
// more difficult, and if we are not looking for a sum or product that is actually possible, just close to a given number,
// it's even harder to do by brute force.

// Genetic algorithms are based on the idea that you can create a chromosome that represents a potential solution to your
// problem. One way of representing such a chromosome is with a binary string of digits. In our example, we could represent
// one chromosome as 0010010111, and decide that 0 means that the corresponding number is in the "sum" pile and 1 means it
// is in the "product" pile, so this chromosome gives us 1+2+4+5+7=19 and 3*6*8*9*10=12960. Not very close. But the point is
// that you can easily represent any potential solution as a binary string!

// Now, the key to a genetic algorithm is to generate many chromosomes, a large population, if you will. The "genetic" part
// of the name comes from the fact that we will, in a sense, let evolution bring our chromosomes as close as possible to our
// desired solution. So what we do is generate a population of random chromosomes. Then we calculate the fitness of those
// chromosomes in whatever way fits the problem. In our case, we want to minimize the absolute difference of the sum from
// the ideal sum and likewise for the product, so one way we can calculate a "score" of how good our estimate is is
// sqrt((chromosome sum - ideal sum)^2+(chromosome product - ideal product)^2). We want to, of course, maximize fitness, so
// the closer our score is to 0 (that is, the closer the chromosome is to ideal), the bigger the fitness is. So what we can
// do is let our fitness be 1/(score + 1); a fitness of 0 means it's nowhere near what we want, and a fitness of 1 means we
// have exactly the right answer!

// The evolution step involves taking a look at our population and selecting by fitness. This is done in a few steps:

// Select two chromosomes from our original population. This is not done purely randomly. This is done using what is called
// "roulette wheel selection", where the chances of picking a chromosome are proportional to its fitness! This means we are
// more likely to pick out chromosomes that are closer to our answer. Duplicate these chromosomes.
// With a probability p_c, a crossover occurs between these two new chromosomes. That means at some random bit along the
// length of the chromosome, we cut off the rest of the chromosome and switch it with the cut off part of the other one. In
// other words, say we have 01011010 and 11110110 and we crossover at the 3rd bit. This results in 010 10110 and 111 11010.
// With a probability p_m, a mutation can occur at every bit along each new chromosome; the mutation rate is typically very
// small.
// Add these two new chromosomes into our new population and repeat steps 1-3 until you have a new population the same size
// as the original one. For obvious reasons, this is easier if you start off with an even sized original population.
// Our goal here is to run the evolution process many times. Eventually, all the chromosomes in our population will have a
// fitness close to 1! When we feel we have done enough runs, that is the time to cut it off, find the chromosome with the
// highest fitness, and return that as the result.

// Your task
// We'll keep this task fairly simple. You will be given an outline of a GeneticAlgorithm class with a few methods.
// The crossover and mutate methods are self-explanatory: they take in two chromosomes or one and a probability (respectively)
// and return a crossed-over pair or a mutated chromosome. The generate method generates a random chromosome of a given length
// (use this in your run method to create a population). The select method will take a population and a corresponding list of
// fitnesses and return two chromosomes selected with the roulette wheel method. The run method will take a fitness function
// that accepts a chromosome and returns the fitness of that chromosome, the length of the chromosomes to generate (should be
// the same length as the goal chromosome), the crossover and mutation probabilities, and an optional number of iterations
// (default to 100). Make the population size whatever you want; 100 is a good number but anywhere between 50 and 1000 will
// work just fine (although the bigger, the slower). After the iterations are finished, the method returns the chromosome it
// deemed to be fittest. This fitness function will be preloaded (Helper.Fitness in C#)! What the test will do is generate a
// random binary string of 35 digits (a random Integer with 35 bits for Ruby), and your algorithm must discover that string!
// The fitness will be calculated in a way similar to above, where the score of a chromosome is the number of bits that differ
// from the goal string.

// The crossover probability we will use is 0.6 and the mutation probability we will use is 0.002. Now, since the chromosome
// length is small, 100 iterations should be enough to get the correct answer every time. The test fixture will run the
// algorithm 10 times on 10 different goal strings. If not all of them work, then you can try again and you'll probably be fine.

// Good luck and have fun!

var GeneticAlgorithm = function () {};
// We'll keep this task fairly simple. You will be given an outline of a GeneticAlgorithm class with a few methods.

GeneticAlgorithm.prototype.generate = function (length) {
  //  - The generate method generates a random chromosome of a given length (use this in your run method to create
  //    a population).
  let result = '';
  for (let i = 0; i < length; ++i) result += `${Math.floor(2 * Math.random())}`;
  return result;
};

GeneticAlgorithm.prototype.select = function (population, fitnesses) {
  //  - The select method will take a population and a corresponding list of fitnesses and return two chromosomes
  //    selected with the roulette wheel method.
  let resultIndexes = [];

  const rouletteWheel = () => {
    // count the sum of fitnesses (excluding the element that's been selected already)
    let sumOfFitnesses = fitnesses
      .filter((element, index) => !resultIndexes.includes(index))
      .reduce((sum, f) => sum + f);
    // multiply random with the sum of fitnesses
    let randomSelector = Math.random() * sumOfFitnesses;
    for (let i = 0; i < fitnesses.length; ++i) {
      // excluding the element that's been already selected
      if (!resultIndexes.includes(i)) {
        // subtract fitnesses one by one
        randomSelector -= fitnesses[i];
        // return the selected index, when the random number goes below 0
        if (randomSelector < 0) return i;
      }
    }
  };
  // 1st selection
  resultIndexes.push(rouletteWheel());

  // 2nd selection
  resultIndexes.push(rouletteWheel());

  return [population[resultIndexes[0]], population[resultIndexes[1]]];
};

GeneticAlgorithm.prototype.mutate = function (chromosome, p) {
  //  - mutate method is self-explanatory: take in one chromosome and a probability and return a mutated chromosome.
  let result = '';
  // try every bit
  for (let i = 0; i < chromosome.length; ++i) {
    // with p chance switch the bit 0->1 or 1->0.
    if (Math.random() < p) {
      result += chromosome[i] === '0' ? '1' : '0';
    } else {
      result += chromosome[i];
    }
  }
  return result;
};

GeneticAlgorithm.prototype.crossover = function (chromosome1, chromosome2) {
  //  - the crossover method is self-explanatory: take in two chromosomes and return a crossed-over pair of
  //    chromosome.
  // there are (chromosome1.length - 1) possible cuts between the bits
  let randomBit = Math.floor(Math.random() * (chromosome1.length - 1) + 1);

  return [
    chromosome1.substr(0, randomBit) + chromosome2.substr(randomBit),
    chromosome2.substr(0, randomBit) + chromosome1.substr(randomBit),
  ];
};

//  - The run method will take:
//     - a fitness function that accepts a chromosome and returns the fitness of that chromosome,
//        - This fitness function will be preloaded (Helper.Fitness in C#)! What the test will do is generate a
//          random binary string of 35 digits (a random Integer with 35 bits for Ruby), and your algorithm must
//          discover that string!
//        - The fitness will be calculated in a way similar to above, where the score of a chromosome is the
//          number of bits that differ from the goal string.
//     - the length of the chromosomes to generate (should be the same length as the goal chromosome)
//     - crossover probability
//        - the crossover probability we will use is 0.6
//     - mutation probability
//        - the mutation probability we will use is 0.002.
//     - an optional number of iterations (default to 100).
//        - since the chromosome length is small, 100 iterations should be enough to get the correct answer every
//          time.
GeneticAlgorithm.prototype.run = function (fitness, length, p_c, p_m, iterations = 100) {
  // Make the population size whatever you want; 100 is a good number but anywhere between 50 and 1000 will work
  // just fine (although the bigger, the slower).
  let populationSize = 100;
  let population = [];
  for (let i = 0; i < populationSize; ++i) {
    population.push(this.generate(length));
  }

  // evolution
  for (let i = 0; i < iterations; ++i) {
    let fitnesses = [];
    // calculate fitnesses
    population.forEach((pop) => fitnesses.push(fitness(pop)));

    let newPopulation = [];

    while (newPopulation.length < populationSize) {
      // select two chromosomes
      let selectedChromosomes = this.select(population, fitnesses);

      // with a p_c probability, crossover happens
      if (Math.random() < p_c) {
        selectedChromosomes = this.crossover(selectedChromosomes[0], selectedChromosomes[1]);
      }

      // with a p_m probability, mutation happoens
      selectedChromosomes[0] = this.mutate(selectedChromosomes[0], p_m);
      selectedChromosomes[1] = this.mutate(selectedChromosomes[1], p_m);

      // add to the new population
      newPopulation.push(selectedChromosomes[0]);
      newPopulation.push(selectedChromosomes[1]);
    }
    population = newPopulation;
  }

  // After the iterations are finished, the method returns the chromosome it deemed to be fittest.
  let maxIndex = 0,
    maxValue = fitness(population[0]);
  for (let i = 1; i < population.length; ++i) {
    let currentFitness = fitness(population[i]);
    if (currentFitness > maxValue) {
      maxValue = currentFitness;
      maxIndex = i;
    }
  }
  return population[maxIndex];
};
