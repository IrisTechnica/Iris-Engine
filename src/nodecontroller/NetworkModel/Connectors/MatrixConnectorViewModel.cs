using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace NetworkModel {
    public class MatrixConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public MatrixConnectorViewModel(string name) : base(name, typeof(Matrix4x4), EntityGroupTypes.Enumerable) {
        }

        public new Matrix4x4 Entity {
            get {
                if ( entity == null ) entity = Matrix4x4.Identity;
                return (Matrix4x4)Convert.ChangeType(entity, typeof(Matrix4x4));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
