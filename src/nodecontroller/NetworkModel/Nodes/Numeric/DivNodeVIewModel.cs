using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModel
{
    public class DivNodeViewModel : AbstractNodeViewModel
    {
        #region Internal Classes [None Internal constraints]

        public class InternalInputs
        {
            private FloatConnectorViewModel div1;
            private FloatConnectorViewModel div2;

            public FloatConnectorViewModel Div1
            {
                get
                {
                    if (div1 == null) div1 = new FloatConnectorViewModel("Div 1");
                    return div1;
                }

                set
                {
                    div1 = value;
                }
            }

            public FloatConnectorViewModel Div2
            {
                get
                {
                    if (div2 == null) div2 = new FloatConnectorViewModel("Div 2");
                    return div2;
                }

                set
                {
                    div2 = value;
                }
            }
        }

        public class InternalOutputs
        {
            private FloatConnectorViewModel divValue;

            public FloatConnectorViewModel DivValue
            {
                get
                {
                    if (divValue == null) divValue = new FloatConnectorViewModel("Value");
                    return divValue;
                }

                set
                {
                    divValue = value;
                }
            }
        }

        #endregion

        #region Private Data Members

        private InternalInputs inputs = new InternalInputs();
        private InternalOutputs outputs = new InternalOutputs();

        #endregion

        #region Private Methods

        private void Initialize()
        {
            this.InputConnectors.Add(inputs.Div1);
            this.InputConnectors.Add(inputs.Div2);
            this.OutputConnectors.Add(outputs.DivValue);
        }

        #endregion

        #region Public Properties

        public InternalInputs Inputs
        {
            get
            {
                return inputs;
            }

            set
            {
                inputs = value;
            }
        }

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

        public DivNodeViewModel() : base("Div")
        {
            Initialize();
        }

        public override void Calculate()
        {
            try
            {
                outputs.DivValue.NoRaiseEntity = inputs.Div1.Entity / inputs.Div2.Entity;
                if (Single.IsNaN(outputs.DivValue.Entity))throw new DivideByZeroException();
            }catch(Exception)
            {
                outputs.DivValue.NoRaiseEntity = 0;
                Console.WriteLine("Warning ## Zero Divide!!");
            }
            Console.WriteLine("div {0} / {1} to {2}", inputs.Div1.Entity, inputs.Div2.Entity, outputs.DivValue.Entity);
        }

        #endregion
    }
}
