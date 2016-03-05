using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class BooleanConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public BooleanConnectorViewModel(string name) : base(name, typeof(Boolean), EntityGroupTypes.Enumerable) {
        }

        public new Boolean Entity {
            get {
                if ( entity == null ) entity = new Boolean();
                return (Boolean)Convert.ChangeType(entity, typeof(Boolean));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
