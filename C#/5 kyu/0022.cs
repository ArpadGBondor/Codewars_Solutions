// Kata: Catch the Bus
// Link: https://www.codewars.com/kata/67ca09c53513c2e514fdf3d4

// The book "Guide to Teaching Puzzle-based Learning" includes the following
// puzzle:

// "A boy sometimes misses the bus. The bus is supposed to leave at 8:00, but it
// arrives at the stop some time between 7:58 and 8:02 and departs immediately
// once everyone is on board. The boy tries to reach the stop early, but due to
// various circumstances he arrives some time between 7:55 and 8:01. How often
// does the boy miss the bus?" (Text edited for brevity.) The book explains how
// to find the solution, which is 18.75%.

// Let's solve this problem in general. Inputs are the bus range first, followed
// by the boy range. Both ranges are tuples (or lists or arrays, depending on
// language) of two elements; the second time is guaranteed to be later than the
// first. The bus and boy are equally likely to arrive at any time in their
// range. You don't have to take into account the time that the bus waits -
// assume people board the bus instantly :-). The boy makes the bus only if he
// arrives before or at the moment it does. Compute how often the boy misses the
// bus, as a percentage.

// Times are given as strings containing hour, minute, and AM/PM. Example:
// (("7:58 AM", "8:02 AM"), ("7:55 AM", "8:01 AM")) should return 18.75 Answers
// are accepted if within 0.001 of the solution.

// Note: The bus runs between 2am and 11pm. The boy's times will be sufficiently
// close to the bus times so that calculating across to the previous or next day
// is not needed.

// Other "Catching Bus" kata: Coding 3min : Waiting for a Bus and Bus Timer

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

public class CatchBus
{
    public static double CatchTheBus((string, string) busTimes, (string, string) boyTimes)
    {
      (int,int) busMinutes = (TimeToMinutes(busTimes.Item1),TimeToMinutes(busTimes.Item2));
      (int,int) boyMinutes = (TimeToMinutes(boyTimes.Item1),TimeToMinutes(boyTimes.Item2));
      if (boyMinutes.Item2 < busMinutes.Item1) return 0;
      if (boyMinutes.Item1 > busMinutes.Item2) return 100;

      int boyTimeFrameMinutes = boyMinutes.Item2 - boyMinutes.Item1;
      int busTimeFrameMinutes = busMinutes.Item2 - busMinutes.Item1;
      
      double chanceToMiss = 0;
      
      // if boyMinutes.Item2 < busMinutes.Item2 then the boy can't miss the bus in this timeframe
      
      if (busMinutes.Item2 < boyMinutes.Item2) {
        // then the boy has 100% chance of missing a bus in [busMinutes.Item2 - boyMinutes.Item2] timeframe
        // multiplied by (boyMinutes.Item2 - busMinutes.Item2) / boyTimeFrameMinutes
        chanceToMiss += (double)(boyMinutes.Item2 - busMinutes.Item2) / boyTimeFrameMinutes;
      }      
      
      // on overlaping interval there's 1/2 chance to miss the bus
      // multiplied by chance of bus coming within this interval
      // multiplied by chance of boy coming within this interval
      double overlapingMinutes = Math.Min(busMinutes.Item2,boyMinutes.Item2) - Math.Max(busMinutes.Item1,boyMinutes.Item1);
      chanceToMiss += 0.5 * (overlapingMinutes/boyTimeFrameMinutes) * (overlapingMinutes/busTimeFrameMinutes);

      // if boyMinutes.Item1 < busMinutes.Item1 then on [boyMinutes.Item1,busMinutes.Item1] interval boy has 0% chance to miss the bus
      if (busMinutes.Item1 < boyMinutes.Item1) {
        // then on [busMinutes.Item1,boyMinutes.Item1] interval boy has 100% chance to miss the bus, 
        // and the bus has (boyMinutes.Item1 - busMinutes.Item1) / busTimeFrameMinutes chance to arrive in this interval
        // and this chance only matters when the boy arrived during the overlapping timeframe. (otherwise we already counted him missing the bus)
        chanceToMiss += ((double)(boyMinutes.Item1 - busMinutes.Item1) / busTimeFrameMinutes) *(overlapingMinutes/boyTimeFrameMinutes);
      }
      
      return 100*chanceToMiss;
    }
    
    private static int TimeToMinutes(string time) 
    {  
      DateTime dt = DateTime.ParseExact(time, new[] {"h:mm tt","hh:mm tt"}, CultureInfo.InvariantCulture);
      return dt.Hour * 60 + dt.Minute;
    }
    
}
