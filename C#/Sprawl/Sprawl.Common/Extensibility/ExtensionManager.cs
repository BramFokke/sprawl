using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sprawl.Common.Extensibility
{

    /// <summary>
    /// Responsible for creating the modules that make up the game
    /// </summary>
    public class ExtensionManager : IDisposable
    {
        public ExtensionManager(Mods mods)
        {
            this.mods = mods;
        }

        private readonly Mods mods;
        private readonly Dictionary<Type, object> instances = new Dictionary<Type, object>();
        private readonly List<IUpdate> updateables = new List<IUpdate>(); 

        public T Get<T>() where T: class
        {
            return (T)Get(typeof(T), new Stack<Type>());
        }

        public object Get(Type type)
        {
            return Get(type, new Stack<Type>());
        }

        private object Get(Type type, Stack<Type> stack)
        {
            if (stack.Contains(type))
            {
                throw new InvalidOperationException("Cyclical dependency. Instantiation stack: " + string.Join(" -> ", stack.Select(t => t.FullName).ToArray()));
            }
            try
            {
                stack.Push(type);
                object result;
                if (!instances.TryGetValue(type, out result))
                {
                    instances.Add(type, result = Instantiate(type, stack));
                }
                return result;
            }
            finally
            {
                stack.Pop();
            }
        }

        private IService Instantiate(Type type, Stack<Type> stack)
        {
            if (type.IsInterface)
            {
                // Walk up the mod list and find the first 
                type = GetImplementingType(type);
            }
            var constructors = type.GetConstructors();
            if (constructors.Length != 1)
            {
                throw new InvalidOperationException("Currently, only a single constructor is supported");
            }
            var constructor = constructors.Single();
            var parameters = constructor.GetParameters();
            var values = new object[constructor.GetParameters().Length];
            for (var p = 0; p < parameters.Length; p++)
            {
                values[p] = Get(parameters[p].ParameterType, stack);
            }
            return (IService)constructor.Invoke(parameters);
        }

        private Type GetImplementingType(Type type)
        {
            foreach (var mod in mods.Reverse())
            {
                var candidates =
                    mod
                        .Types()
                        .Where(t => !t.IsAbstract && t.IsClass)
                        .Where(t => type.IsAssignableFrom(t))
                        .ToList();
                if (candidates.Any())
                {
                    if (candidates.Count > 1)
                    {
                        throw new InvalidOperationException($"There are multiple implementations of {type} in mod {mod}");
                    }
                    return candidates.Single();
                }
            }
            throw new InvalidOperationException($"No implementation of {type} has been found");
        }

        public void Dispose()
        {
            foreach (var instance in instances.Values.OfType<IDisposable>())
            {
                instance.Dispose();
            }
            instances.Clear();
        }


        public void Update(float deltaSeconds)
        {
            foreach (var updateable in updateables)
            {
                updateable.Update(deltaSeconds);
            }
        }

    }


}
