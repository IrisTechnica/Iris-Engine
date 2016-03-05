using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class LightConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public LightConnectorViewModel(string name) : base(name, typeof(LightData), EntityGroupTypes.Enumerable) {
        }

        public new LightData Entity {
            get {
                if ( entity == null ) entity = new LightData();
                return (LightData)Convert.ChangeType(entity, typeof(LightData));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
