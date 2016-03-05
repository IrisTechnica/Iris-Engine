using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class NotBooleanNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private BooleanConnectorViewModel V1;

            public BooleanConnectorViewModel Not {
                get {
                    if ( V1 == null ) V1 = new BooleanConnectorViewModel("Not");
                    return V1;
                }

                set {
                    V1 = value;
                }
            }
        }

        public class InternalOutputs {
            private BooleanConnectorViewModel notValue;

            public BooleanConnectorViewModel NotValue {
                get {
                    if ( notValue == null ) notValue = new BooleanConnectorViewModel("Value");
                    return notValue;
                }

                set {
                    notValue = value;
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
            this.InputConnectors.Add(inputs.Not);
            this.OutputConnectors.Add(outputs.NotValue);
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

        public NotBooleanNodeViewModel( ) : base("Not", typeof(Boolean)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.NotValue.NoRaiseEntity = !inputs.Not.Entity;
            Console.WriteLine("not {0} to {1}", inputs.Not.Entity, outputs.NotValue.Entity);
        }

        #endregion
    }
}
