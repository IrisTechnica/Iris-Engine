using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel
{
    public class FloatConnectorViewModel : ConnectorViewModel
    {
        #region Private Data Members

        private float entity = 0;

        #endregion

        #region Public Methods

        public FloatConnectorViewModel(string name) : base(name, typeof(float))
        {
        }

        public float Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        #endregion
    }
}
