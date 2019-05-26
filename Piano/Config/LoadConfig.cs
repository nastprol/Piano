using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Piano
{
    public class LoadConfig
    {
        public readonly Dictionary<string, Type> Modes;
        public readonly Dictionary<string, Type> Loaders;
        public readonly Dictionary<string, Type> InputControls;
        public readonly Dictionary<string, Type> Locators;


        public LoadConfig()
        {
            var assembleyTypes = Assembly
               .GetExecutingAssembly()
               .GetTypes();
            Modes = assembleyTypes
                .Where(t => t.GetInterfaces().Contains(typeof(IGameMode)))
                .ToDictionary(t => ((DescriptionAttribute)Attribute.GetCustomAttribute(t, typeof(DescriptionAttribute))).Name);
            Loaders = assembleyTypes
                .Where(t => t.GetInterfaces().Contains(typeof(IMelodyLoader)))
                .ToDictionary(t => ((DescriptionAttribute)Attribute.GetCustomAttribute(t, typeof(DescriptionAttribute))).Name);
            InputControls = assembleyTypes
               .Where(t => t.GetInterfaces().Contains(typeof(IInputControl)))
               .ToDictionary(t => ((DescriptionAttribute)Attribute.GetCustomAttribute(t, typeof(DescriptionAttribute))).Name);
            Locators = assembleyTypes
              .Where(t => t.GetInterfaces().Contains(typeof(IMelodyLocator)))
               .ToDictionary(t => ((DescriptionAttribute)Attribute.GetCustomAttribute(t, typeof(DescriptionAttribute))).Name);            
        }
    }
}
