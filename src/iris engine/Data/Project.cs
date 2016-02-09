using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace iris_engine.Data
{
    class Project
    {
        private string _name;
        private string _filePath;

        private int _testObject;

        private IList<int> _idList;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }

        }

        public bool Load(string path)
        {
            this._filePath = path;
            if (Path.GetFileName(this._filePath) == "")
                return false;

            if(!LoadDataBase())return false;

            return true;
        }

        private bool LoadDataBase()
        {
            var temporary_name = Path.GetFileNameWithoutExtension(this._filePath);
            var current_directory = Path.GetDirectoryName(this._filePath);
            var query = "Data Source=" + Path.Combine(current_directory, temporary_name + ".db");

            var sql = new SQLiteConnection(query);

            return true;
        }
    }
}
