using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel
{
    public class IntegerConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public IntegerConnectorViewModel(string name) : base(name, typeof(int), EntityGroupTypes.Enumerable) {
        }

        public new int Entity {
            get {
                if ( entity == null ) entity = new int();
                return (int)Convert.ChangeType(entity, typeof(int));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
