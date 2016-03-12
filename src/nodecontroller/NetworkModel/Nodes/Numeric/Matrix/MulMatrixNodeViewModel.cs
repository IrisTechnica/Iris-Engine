using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace NetworkModel {
    public class MulMatrixNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private MatrixConnectorViewModel mul1;
            private MatrixConnectorViewModel mul2;

            public MatrixConnectorViewModel Mul1 {
                get {
                    if ( mul1 == null ) mul1 = new MatrixConnectorViewModel("Mul 1");
                    return mul1;
                }

                set {
                    mul1 = value;
                }
            }

            public MatrixConnectorViewModel Mul2 {
                get {
                    if ( mul2 == null ) mul2 = new MatrixConnectorViewModel("Mul 2");
                    return mul2;
                }

                set {
                    mul2 = value;
                }
            }
        }

        public class InternalOutputs {
            private MatrixConnectorViewModel mulValue;

            public MatrixConnectorViewModel MulValue {
                get {
                    if ( mulValue == null ) mulValue = new MatrixConnectorViewModel("Value");
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

        public MulMatrixNodeViewModel( ) : base("Mul", typeof(Matrix4x4)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.MulValue.NoRaiseEntity = inputs.Mul1.Entity * inputs.Mul2.Entity;
            Console.WriteLine("mul {0} * {1} to {2}", inputs.Mul1.Entity, inputs.Mul2.Entity, outputs.MulValue.Entity);
        }

        #endregion
    }
}
