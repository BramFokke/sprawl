using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprawl.Calendar
{

    /// <summary>
    /// Represents a moment in time in the game calendar. The game uses a 24 hour calendar
    /// </summary>
    public struct Time
    {
        public Time(float daysSinceEpoch)
        {
            this.DaysSinceEpoch = daysSinceEpoch;
        }

        public float DaysSinceEpoch { get; }

        public override string ToString()
        {
            var days = (int) DaysSinceEpoch;
            var dayFraction = DaysSinceEpoch - days;
            var minutes = (int) (dayFraction*24*60);
            return $"{days}.{(minutes / 60):00}:{(minutes % 60):00}";
        }

        public Time AddSeconds(float seconds)
        {
            return new Time(DaysSinceEpoch + (seconds / (24 * 60)));
        }

        public Time AddDays(float days)
        {
            return new Time(DaysSinceEpoch + days);
        }
    }
}
