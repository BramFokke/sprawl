using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprawl.Common.Extensibility;

namespace Sprawl.Common.Time
{
    public class NowService : Extension, INowService
    {

        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;

    }
}
