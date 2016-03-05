using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel
{
    public class ByteConnectorViewModel : ConnectorViewModel
    {
        #region Private Data Members

        #endregion

        #region Public Methods

        public ByteConnectorViewModel(string name) : base(name, typeof(byte), EntityGroupTypes.Enumerable)
        {
        }

        public new byte Entity
        {
            get {
                if (entity == null) entity = new byte();
                return (byte)Convert.ChangeType(entity,typeof(byte));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
