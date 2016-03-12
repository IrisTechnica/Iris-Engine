using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class DivIntegerNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private IntegerConnectorViewModel div1;
            private IntegerConnectorViewModel div2;

            public IntegerConnectorViewModel Div1 {
                get {
                    if ( div1 == null ) div1 = new IntegerConnectorViewModel("Div 1");
                    return div1;
                }

                set {
                    div1 = value;
                }
            }

            public IntegerConnectorViewModel Div2 {
                get {
                    if ( div2 == null ) div2 = new IntegerConnectorViewModel("Div 2");
                    return div2;
                }

                set {
                    div2 = value;
                }
            }
        }

        public class InternalOutputs {
            private IntegerConnectorViewModel divValue;

            public IntegerConnectorViewModel DivValue {
                get {
                    if ( divValue == null ) divValue = new IntegerConnectorViewModel("Value");
                    return divValue;
                }

                set {
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

        private void Initialize( ) {
            this.InputConnectors.Add(inputs.Div1);
            this.InputConnectors.Add(inputs.Div2);
            this.OutputConnectors.Add(outputs.DivValue);
        }

        #endregion

        #region Public Properties

        public InternalInputs Inputs {
            get {
                return inputs;
            }

            set {
                inputs = value;
            }
        }

        public InternalOutputs Outputs {
            get {
                return outputs;
            }

            set {
                outputs = value;
            }
        }

        #endregion

        #region Public Methods

        public DivIntegerNodeViewModel( ) : base("Div", typeof(int)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.DivValue.NoRaiseEntity = inputs.Div1.Entity + inputs.Div2.Entity;
            Console.WriteLine("div {0} / {1} to {2}", inputs.Div1.Entity, inputs.Div2.Entity, outputs.DivValue.Entity);
        }

        #endregion
    }
}
