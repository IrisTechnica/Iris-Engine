using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModel
{
    public class PrintStringNodeViewModel : AbstractNodeViewModel
    {
        #region Internal Classes [None Internal constraints]

        public class InternalInputs
        {
            private EventConnectorViewModel sync;
            private StringConnectorViewModel string1;

            public EventConnectorViewModel Sync
            {
                get
                {
                    if (sync == null) sync = new EventConnectorViewModel();
                    return sync;
                }

                set
                {
                    sync = value;
                }
            }

            public StringConnectorViewModel String1
            {
                get
                {
                    if (string1 == null) string1 = new StringConnectorViewModel("Value");
                    return string1;
                }

                set
                {
                    string1 = value;
                }
            }
        }

        #endregion

        #region Private Data Members

        private InternalInputs inputs = new InternalInputs();

        #endregion

        #region Private Methods

        private void Initialize()
        {
            this.InputConnectors.Add(inputs.Sync);
            this.InputConnectors.Add(inputs.String1);
        }

        #endregion

        public override void Calculate()
        {
            // TODO コンソールへ吐き出す
        }

        public PrintStringNodeViewModel() : base("PrintString")
        {
            Initialize();
        }
    }
}
