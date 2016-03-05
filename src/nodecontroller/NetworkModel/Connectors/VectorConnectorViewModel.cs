using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class VectorConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public VectorConnectorViewModel(string name) : base(name, typeof(float[]), EntityGroupTypes.Enumerable) {
        }

        public new float[] Entity {
            get {
                if ( entity == null ) entity = new float[3];
                return (float[])Convert.ChangeType(entity, typeof(float[]));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
