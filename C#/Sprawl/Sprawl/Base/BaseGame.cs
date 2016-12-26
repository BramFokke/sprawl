using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprawl.Common;
using Sprawl.Common.Extensibility;

namespace Sprawl.Base
{
    public class BaseGame : Game
    {
        public BaseGame() : base(CreateMods())
        {
        }

        private static Mods CreateMods()
        {
            return 
                new Mods()
                .AddAssembly(typeof(Game).Assembly)
                .AddAssembly(typeof(BaseGame).Assembly);

        }
    }
}
