using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sprawl.Common.Extensibility
{
    public class Mods : IEnumerable<Mod>
    {

        public Mods AddAssembly(Assembly assembly)
        {
            return AddTypes(GetTypes(assembly).ToArray());
        }

        public Mods AddTypes(params Type[] types)
        {
            mods.Add(new Mod(mods.Count, types.ToList()));
            return this;
        }

        private static IEnumerable<Type> GetTypes(Assembly assembly)
        {
            var extensionType = typeof(IExtension);
            return
                assembly
                    .GetTypes()
                    .Where(t => extensionType.IsAssignableFrom(t))
                    .Where(t => t.IsClass && !t.IsAbstract);
        }


        private readonly List<Mod> mods = new List<Mod>();


        public IEnumerator<Mod> GetEnumerator()
        {
            return mods.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mods.GetEnumerator();
        }
    }

    public class Mod
    {
        private int localModId;
        private List<Type> types;

        internal Mod(int localModId, List<Type> types)
        {
            this.localModId = localModId;
            this.types = types;
        }

        public int LocalModId => localModId;

        public IEnumerable<Type> Types()
        {
            return types.ToList();
        }
    }
}
