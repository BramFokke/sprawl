using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprawl.Common.Extensibility
{
    public interface IExtension
    {
        /// <summary>
        /// Local reference to the mod. Higher mod Ids have preference over lower mod ids.
        /// </summary>
        int LocalModId { get; set; }
    }

    public class Extension : IExtension
    {
        public int LocalModId { get; set; }
    }
}
