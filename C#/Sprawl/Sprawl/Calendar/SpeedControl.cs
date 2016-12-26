using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprawl.Common.Extensibility;

namespace Sprawl.Calendar
{
    public class SpeedControl : Extension, IExtension
    {
        /// <summary>
        /// Number of game seconds per actual second. Set to 0 to pause the simulation
        /// </summary>
        public float Acceleration { get; set; } = 24f*60*60/(5*60f); // Default: 5 minutes for a full day

    }
}
