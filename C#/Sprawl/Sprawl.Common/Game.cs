using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprawl.Common.Extensibility;

namespace Sprawl.Common
{
    public class Game : IDisposable
    {

        public Game(Mods mods)
        {
            this.Extensions = new ExtensionManager(mods);
        }

        public ExtensionManager Extensions { get; }

        public void Update(float deltaSeconds)
        {
            Extensions.Update(deltaSeconds);
        }

        public void Dispose()
        {
            Extensions.Dispose();
        }

    }
}
