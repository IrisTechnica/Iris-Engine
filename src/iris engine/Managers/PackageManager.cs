using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iris_engine.Data;

namespace iris_engine.Managers
{
    class PackageManager
    {
        private static PackageManager _instance = new PackageManager();

        public static PackageManager GetInstance()
        {
            return _instance;
        }

        private PackageManager()
        {

        }

        private Dictionary<string, Project> map;

        public Project this[string name]
        {
            set { map[name] = value; }
            get { return map[name]; }
        }

        public void OpenPackage()
        {

        }
    }
}
