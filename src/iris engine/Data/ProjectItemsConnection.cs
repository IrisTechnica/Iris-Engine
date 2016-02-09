using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Data
{
    class ProjectItemsConnection
    {
        private int _id;
        private ProjectItemDesc _desc;

        private ObservableCollection<ProjectItemsConnection> _children;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        internal ProjectItemDesc Desc
        {
            get
            {
                return _desc;
            }

            set
            {
                _desc = value;
            }
        }

        internal ObservableCollection<ProjectItemsConnection> Children
        {
            get
            {
                return _children;
            }

            set
            {
                _children = value;
            }
        }
    }
}
