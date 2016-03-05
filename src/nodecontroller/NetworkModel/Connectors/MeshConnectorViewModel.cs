using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class MeshConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public MeshConnectorViewModel(string name) : base(name, typeof(MeshData), EntityGroupTypes.Enumerable) {
        }

        public new MeshData Entity {
            get {
                if ( entity == null ) entity = new MeshData();
                return (MeshData)Convert.ChangeType(entity, typeof(MeshData));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
