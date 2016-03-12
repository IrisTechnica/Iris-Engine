using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace NetworkModel {
    public class AddVectorNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private VectorConnectorViewModel add1;
            private VectorConnectorViewModel add2;

            public VectorConnectorViewModel Add1 {
                get {
                    if ( add1 == null ) add1 = new VectorConnectorViewModel("Add 1");
                    return add1;
                }

                set {
                    add1 = value;
                }
            }

            public VectorConnectorViewModel Add2 {
                get {
                    if ( add2 == null ) add2 = new VectorConnectorViewModel("Add 2");
                    return add2;
                }

                set {
                    add2 = value;
                }
            }
        }

        public class InternalOutputs {
            private VectorConnectorViewModel addValue;

            public VectorConnectorViewModel AddValue {
                get {
                    if ( addValue == null ) addValue = new VectorConnectorViewModel("Value");
                    return addValue;
                }

                set {
                    addValue = value;
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
            this.InputConnectors.Add(inputs.Add1);
            this.InputConnectors.Add(inputs.Add2);
            this.OutputConnectors.Add(outputs.AddValue);
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

        public AddVectorNodeViewModel( ) : base("Add", typeof(Vector3)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.AddValue.NoRaiseEntity = inputs.Add1.Entity + inputs.Add2.Entity;
            Console.WriteLine("add {0} + {1} to {2}", inputs.Add1.Entity, inputs.Add2.Entity, outputs.AddValue.Entity);
        }

        #endregion
    }
}
