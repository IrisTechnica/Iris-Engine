using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel
{
    public class FloatConnectorViewModel : ConnectorViewModel
    {
        #region Private Data Members

        #endregion

        #region Public Methods

        public FloatConnectorViewModel(string name) : base(name, typeof(float))
        {
        }

        public new float Entity
        {
            get {
                if (entity == null) entity = new float();
                return (float)Convert.ChangeType(entity,typeof(float));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
