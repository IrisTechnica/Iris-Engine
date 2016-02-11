using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Data
{
    class ProjectItemDesc
    {
        private string _name;
        private CompileActionType _compiletype;
        private ProjectItemDataType _type;

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


        internal CompileActionType CompileType {
            get {
                return _compiletype;
            }
            set {
                _compiletype = value;
            }
        }

        internal ProjectItemDataType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public bool IsDirectory()
        {
            return _type == ProjectItemDataType.Directory;
        }
    }
}
