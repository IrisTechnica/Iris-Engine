using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class SoundConnectorViewModel : ConnectorViewModel {
        #region Private Data Members

        #endregion

        #region Public Methods

        public SoundConnectorViewModel(string name) : base(name, typeof(SoundData), EntityGroupTypes.Enumerable) {
        }

        public new SoundData Entity {
            get {
                if ( entity == null ) entity = new SoundData();
                return (SoundData)Convert.ChangeType(entity, typeof(SoundData));
            }
            set { this.SetProperty(ref entity, value); }
        }

        #endregion
    }
}
