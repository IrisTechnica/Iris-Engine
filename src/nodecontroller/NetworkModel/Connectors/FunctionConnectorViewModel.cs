using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModel
{
    public class FunctionConnectorViewModel : ConnectorViewModel
    {
        
        public FunctionConnectorViewModel(string name) : base(name,typeof(Action<object[]>), EntityGroupTypes.Function)
        {

        }

        public new Action<object[]> Entity
        {
            get
            {
                return (Action<object[]>)Convert.ChangeType(entity, typeof(Action<object[]>));
            }
            set { this.SetProperty(ref entity, value); }
        }


    }
}
