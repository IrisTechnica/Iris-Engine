using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Data
{
    class Project
    {
        private string _name;
        private string _actualPath;

        private ObservableCollection<ProjectItem> _childs;

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

        public string ActualPath
        {
            get
            {
                return _actualPath;
            }

            set
            {
                _actualPath = value;
            }
        }

        internal ObservableCollection<ProjectItem> Childs
        {
            get
            {
                return _childs;
            }

            set
            {
                _childs = value;
            }
        }

    }
}
