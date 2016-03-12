using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace NetworkModel {
    public class VectorConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public VectorConnectorViewModel(string name) : base(name, typeof(Vector3), EntityGroupTypes.Enumerable) {
        }

        public new Vector3 Entity {
            get {
                if ( entity == null ) entity = new Vector3();
                return (Vector3)Convert.ChangeType(entity, typeof(Vector3));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
