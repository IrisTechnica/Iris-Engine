using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace NetworkModel {
    public class MulVectorNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private VectorConnectorViewModel mul1;
            private VectorConnectorViewModel mul2;

            public VectorConnectorViewModel Mul1 {
                get {
                    if ( mul1 == null ) mul1 = new VectorConnectorViewModel("Mul 1");
                    return mul1;
                }

                set {
                    mul1 = value;
                }
            }

            public VectorConnectorViewModel Mul2 {
                get {
                    if ( mul2 == null ) mul2 = new VectorConnectorViewModel("Mul 2");
                    return mul2;
                }

                set {
                    mul2 = value;
                }
            }
        }

        public class InternalOutputs {
            private VectorConnectorViewModel mulValue;

            public VectorConnectorViewModel MulValue {
                get {
                    if ( mulValue == null ) mulValue = new VectorConnectorViewModel("Value");
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

        public MulVectorNodeViewModel( ) : base("Mul", typeof(Vector3)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.MulValue.NoRaiseEntity = inputs.Mul1.Entity / inputs.Mul2.Entity;
            Console.WriteLine("mul {0} / {1} to {2}", inputs.Mul1.Entity, inputs.Mul2.Entity, outputs.MulValue.Entity);
        }

        #endregion
    }
}
