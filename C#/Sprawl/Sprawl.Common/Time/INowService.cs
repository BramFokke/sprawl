using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprawl.Common.Extensibility;

namespace Sprawl.Common.Time
{

    /// <summary>
    /// Provides an interface to the real world clock
    /// </summary>
    public interface INowService : IService
    {

        DateTime Now { get; }

        DateTime UtcNow { get; }

    }
}
