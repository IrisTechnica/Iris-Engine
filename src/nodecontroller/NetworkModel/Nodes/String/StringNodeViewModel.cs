using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModel
{
    class StringNodeViewModel : AbstractNodeViewModel
    {
        #region Internal Classes [None Internal constraints]

        public class InternalOutputs
        {
            private StringConnectorViewModel stringValue;

            public StringConnectorViewModel StringValue
            {
                get
                {
                    if (stringValue == null) stringValue = new StringConnectorViewModel("Text");
                    return stringValue;
                }

                set
                {
                    stringValue = value;
                }
            }
        }

        #endregion

        #region Private Data Members

        private InternalOutputs outputs = new InternalOutputs();

        #endregion

        #region Private Methods

        private void Initialize()
        {
            this.OutputConnectors.Add(outputs.StringValue);
        }

        #endregion

        #region Public Properties

        public InternalOutputs Outputs
        {
            get
            {
                return outputs;
            }

            set
            {
                outputs = value;
            }
        }

        #endregion

        #region Public Methods

        public StringNodeViewModel() : base("String")
        {
            Initialize();
        }


        public override void Calculate()
        {
            // donot calculate
            Console.WriteLine("string value : " + outputs.StringValue.Entity);
        }

        #endregion

    }
}
