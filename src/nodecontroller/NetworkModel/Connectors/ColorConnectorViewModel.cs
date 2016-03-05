using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class ColorConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public ColorConnectorViewModel(string name) : base(name, typeof(ColorData), EntityGroupTypes.Enumerable) {
        }

        public new ColorData Entity {
            get {
                if ( entity == null ) entity = new ColorData();
                return (ColorData)Convert.ChangeType(entity, typeof(ColorData));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
