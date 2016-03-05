using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class AddIntegerNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private IntegerConnectorViewModel add1;
            private IntegerConnectorViewModel add2;

            public IntegerConnectorViewModel Add1 {
                get {
                    if ( add1 == null ) add1 = new IntegerConnectorViewModel("Add 1");
                    return add1;
                }

                set {
                    add1 = value;
                }
            }

            public IntegerConnectorViewModel Add2 {
                get {
                    if ( add2 == null ) add2 = new IntegerConnectorViewModel("Add 2");
                    return add2;
                }

                set {
                    add2 = value;
                }
            }
        }

        public class InternalOutputs {
            private IntegerConnectorViewModel addValue;

            public IntegerConnectorViewModel AddValue {
                get {
                    if ( addValue == null ) addValue = new IntegerConnectorViewModel("Value");
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

        public AddIntegerNodeViewModel( ) : base("Add", typeof(int)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.AddValue.NoRaiseEntity = inputs.Add1.Entity + inputs.Add2.Entity;
            Console.WriteLine("add {0} + {1} to {2}", inputs.Add1.Entity, inputs.Add2.Entity, outputs.AddValue.Entity);
        }

        #endregion
    }
}
