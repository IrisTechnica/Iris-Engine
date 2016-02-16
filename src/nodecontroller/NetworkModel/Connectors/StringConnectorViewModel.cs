using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModel
{
    public class StringConnectorViewModel : ConnectorViewModel
    {
        #region Private Data Members

        #endregion

        public StringConnectorViewModel(string name) : base(name,typeof(string))
        {
        }

        public new string Entity
        {
            get {
                if (entity == null) entity = "";
                return (string)Convert.ChangeType(entity,typeof(string));
            }
            set{ this.SetProperty(ref entity, value); }
        }

    }
}
