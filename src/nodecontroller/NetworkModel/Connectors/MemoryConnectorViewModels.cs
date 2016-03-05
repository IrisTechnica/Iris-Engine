using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModel
{
    class MemoryConnectorViewModel : ConnectorViewModel
    {

        public MemoryConnectorViewModel(string name) : base(name, typeof(MemoryConnectorViewModel), EntityGroupTypes.Array)
        {
        }

        public new List<float> Entity
        {
            get
            {
                if (entity == null) entity = new List<float>();
                return (List<float>)Convert.ChangeType(entity, typeof(List<float>));
            }
            set { this.SetProperty(ref entity, value); }
        }
    }
}
