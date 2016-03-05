using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Attributes
{
    [System.AttributeUsageAttribute(AttributeTargets.Class)]
    public class OnStartupSingletonInitializeAttribute : Attribute
    {
    }
}
