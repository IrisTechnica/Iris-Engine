using iris_engine.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Util
{
    /// <summary>
    /// Usage : run this class in App.cs
    /// </summary>
    class OnStartupSingletonInitializeAttributeSolver
    {
        private static OnStartupSingletonInitializeAttributeSolver instance = new OnStartupSingletonInitializeAttributeSolver();

        public static OnStartupSingletonInitializeAttributeSolver GetInstance()
        {
            return instance;
        }

        public void Run()
        {
            var assembly = Assembly.GetExecutingAssembly();

            List<Type> types = new List<Type>(assembly.GetTypes());

            foreach(var type in types)
            {
                var customAttributes = type.CustomAttributes;
                foreach(var customAttribute in customAttributes)
                {
                    if(customAttribute.AttributeType == typeof(OnStartupSingletonInitializeAttribute))
                    {
                        var method = type.GetMethod("GetInstance", BindingFlags.Static);
                        if(method != null)method.Invoke(null,null);
                    }
                }
            }
        }

    }
}
