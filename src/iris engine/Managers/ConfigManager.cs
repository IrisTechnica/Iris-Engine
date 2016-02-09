using iris_engine.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Managers
{
    class ConfigManager
    {
        private static ConfigManager _instance = new ConfigManager();

        private static ConfigManager GetInstance()
        {
            return _instance;
        }

        private Dictionary<string,string> map;

        private ConfigManager()
        {
            var assembly_path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var assembly_directory = Directory.GetParent(assembly_path);

            var config_directory = Path.Combine(assembly_path, "Config");
            if(!Directory.Exists(config_directory))
            {
                // Configディレクトリが存在しない場合作る
                Directory.CreateDirectory(config_directory);
            }
            var config_path = Path.Combine(config_directory, "app.cfg");
            map = Json.Load(config_path);
        }

        public string this[string name]
        {
            set { map[name] = value; }
            get { return map[name]; }
        }

    }
}
