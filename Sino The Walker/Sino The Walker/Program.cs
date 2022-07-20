using System;
using System.Linq;

namespace Sino_The_Walker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] time = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            int steps = int.Parse(Console.ReadLine()) % 86400;
            int secondPerStep = int.Parse(Console.ReadLine()) % 86400;

            int hour = time[0];
            int minute = time[1];
            int second = time[2];

            int totalSeconds = steps * secondPerStep;
            int addingSeconds = totalSeconds % 60;
            
            int totalMinutes = (totalSeconds - addingSeconds) / 60;
            int addingMinutes = totalMinutes % 60;

            int addingHours = (totalMinutes - addingMinutes) /  60;

            second += addingSeconds;
            if (second > 59)
            {
                second -= 60;
                minute += 1;
            }
            minute += addingMinutes;
            if (minute > 59)
            {
                minute -= 60;
                hour += 1;
            }
            hour += addingHours;
            if (hour > 23)
            {
                hour %= 24;
            }

            Console.WriteLine($"Time Arrival: {hour:d2}:{minute:d2}:{second:d2}");
        }
    }
}
