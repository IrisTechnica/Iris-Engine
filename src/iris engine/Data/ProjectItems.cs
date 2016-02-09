using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Data
{
    class ProjectItems
    {
        private ObservableCollection<ProjectItemsConnection> _items;

        internal ObservableCollection<ProjectItemsConnection> Items
        {
            get
            {
                return _items;
            }

            set
            {
                _items = value;
            }
        }
    }
}
