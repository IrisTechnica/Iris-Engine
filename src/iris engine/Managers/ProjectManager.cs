using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iris_engine.Data;

namespace iris_engine.Managers
{
    class ProjectManager
    {
        private static ProjectManager _instance = new ProjectManager();

        public static ProjectManager GetInstance()
        {
            return _instance;
        }

        private ProjectManager()
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
