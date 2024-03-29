// Kata: Sum of Intervals
// Link: https://www.codewars.com/kata/52b7ed099cdc285c300001cd

// Write a function called sumIntervals/sum_intervals() that accepts an array of intervals, and returns the sum of all the interval lengths. Overlapping intervals should only be counted once.

// Intervals
// Intervals are represented by a pair of integers in the form of an array. The first value of the interval will always be less than the second value. Interval example: [1, 5] is an interval from 1 to 5. The length of this interval is 4.

// Overlapping Intervals
// List containing overlapping intervals:

// [
//    [1,4],
//    [7, 10],
//    [3, 5]
// ]
// The sum of the lengths of these intervals is 7. Since [1, 4] and [3, 5] overlap, we can treat the interval as [1, 5], which has a length of 4.

// Examples:
// sumIntervals( [
//    [1,2],
//    [6, 10],
//    [11, 15]
// ] ); // => 9

// sumIntervals( [
//    [1,4],
//    [7, 10],
//    [3, 5]
// ] ); // => 7

// sumIntervals( [
//    [1,5],
//    [10, 20],
//    [1, 6],
//    [16, 19],
//    [5, 11]
// ] ); // => 19

function sumIntervals(intervals) {
  let nonOverlappingIntervals = [];
  let deleteElement = [];
  for (let i = 0; i < intervals.length; ++i) {
    for (let j = 0; j < nonOverlappingIntervals.length; ++j) {
      // check if intervals conflict
      if (
        (intervals[i][0] >= nonOverlappingIntervals[j][0] && intervals[i][0] <= nonOverlappingIntervals[j][1]) ||
        (intervals[i][1] >= nonOverlappingIntervals[j][0] && intervals[i][1] <= nonOverlappingIntervals[j][1]) ||
        (nonOverlappingIntervals[j][0] >= intervals[i][0] && nonOverlappingIntervals[j][0] <= intervals[i][1]) ||
        (nonOverlappingIntervals[j][1] >= intervals[i][0] && nonOverlappingIntervals[j][1] <= intervals[i][1])
      ) {
        // create new interval from the two overlapping intervals
        intervals[i][0] = Math.min(intervals[i][0], nonOverlappingIntervals[j][0]);
        intervals[i][1] = Math.max(intervals[i][1], nonOverlappingIntervals[j][1]);
        // remove non-overlapping element, because the new interval might overlap with other elements
        deleteElement.push(j);
      }
    }
    // remove elements outside of the loop
    while (deleteElement.length > 0) nonOverlappingIntervals.splice(deleteElement.pop(), 1);
    // add interval to non-overlapping intervals
    nonOverlappingIntervals.push(intervals[i]);
  }
  return nonOverlappingIntervals.reduce((a, i) => a + i[1] - i[0], 0);
}
