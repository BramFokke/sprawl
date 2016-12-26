using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprawl.Base;
using Sprawl.Common.Extensibility;

namespace Sprawl.Calendar
{
    public class DefaultCalendarService : Extension, ICalendarService, IExtension, IUpdate
    {

        public DefaultCalendarService(SpeedControl speed)
        {
            this.speed = speed;
        }

        private readonly SpeedControl speed;

        public void Update(float deltaSeconds)
        {
            Advance(deltaSeconds * speed.Acceleration);
        }

        public void Advance(float seconds)
        {
            Now = Now.AddSeconds(seconds);
        }

        public bool IsWeekend(Time time)
        {
            return GetDayOfWeek(time) == DayOfWeek.Saturday || GetDayOfWeek(time) == DayOfWeek.Sunday;
        }

        public DayOfWeek GetDayOfWeek(Time time)
        {
            return (DayOfWeek) (int) time.DaysSinceEpoch;
        }

        public Time Now { get; private set; }

    }
}
