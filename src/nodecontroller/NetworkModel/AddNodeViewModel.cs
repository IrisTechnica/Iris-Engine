using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel
{
    public class AddNodeViewModel : AbstractNodeViewModel
    {

        #region Internal Classes

        internal class InternalInputs
        {
            private FloatConnectorViewModel add1;
            private FloatConnectorViewModel add2;

            public FloatConnectorViewModel Add1
            {
                get
                {
                    if (add1 == null) add1 = new FloatConnectorViewModel("Add 1");
                    return add1;
                }

                set
                {
                    add1 = value;
                }
            }

            public FloatConnectorViewModel Add2
            {
                get
                {
                    if (add2 == null) add2 = new FloatConnectorViewModel("Add 2");
                    return add2;
                }

                set
                {
                    add2 = value;
                }
            }
        }

        internal class InternalOutputs
        {
            private FloatConnectorViewModel addValue;

            public FloatConnectorViewModel AddValue
            {
                get
                {
                    if (addValue == null) addValue = new FloatConnectorViewModel("Value");
                    return addValue;
                }

                set
                {
                    addValue = value;
                }
            }
        }

        #endregion

        #region Private Data Members

        private InternalInputs inputs = new InternalInputs();
        private InternalOutputs outputs = new InternalOutputs();

        #endregion

        #region Public Methods

        public AddNodeViewModel() : base("Add")
        {
            Initialize();
        }

        public override void Calculate()
        {
            outputs.AddValue.Entity = inputs.Add1.Entity + inputs.Add2.Entity;
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            this.InputConnectors.Add(inputs.Add1);
            this.InputConnectors.Add(inputs.Add2);
            this.OutputConnectors.Add(outputs.AddValue);
        }

        #endregion

    }
}
