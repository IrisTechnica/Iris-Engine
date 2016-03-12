using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class MulIntegerNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private IntegerConnectorViewModel mul1;
            private IntegerConnectorViewModel mul2;

            public IntegerConnectorViewModel Mul1 {
                get {
                    if ( mul1 == null ) mul1 = new IntegerConnectorViewModel("Mul 1");
                    return mul1;
                }

                set {
                    mul1 = value;
                }
            }

            public IntegerConnectorViewModel Mul2 {
                get {
                    if ( mul2 == null ) mul2 = new IntegerConnectorViewModel("Mul 2");
                    return mul2;
                }

                set {
                    mul2 = value;
                }
            }
        }

        public class InternalOutputs {
            private IntegerConnectorViewModel mulValue;

            public IntegerConnectorViewModel MulValue {
                get {
                    if ( mulValue == null ) mulValue = new IntegerConnectorViewModel("Value");
                    return mulValue;
                }

                set {
                    mulValue = value;
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
            this.InputConnectors.Add(inputs.Mul1);
            this.InputConnectors.Add(inputs.Mul2);
            this.OutputConnectors.Add(outputs.MulValue);
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

        public MulIntegerNodeViewModel( ) : base("Mul", typeof(int)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.MulValue.NoRaiseEntity = inputs.Mul1.Entity + inputs.Mul2.Entity;
            Console.WriteLine("mul {0} * {1} to {2}", inputs.Mul1.Entity, inputs.Mul2.Entity, outputs.MulValue.Entity);
        }

        #endregion
    }
}
