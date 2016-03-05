using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class OrBooleanNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private BooleanConnectorViewModel v1;
            private BooleanConnectorViewModel v2;

            public BooleanConnectorViewModel V1 {
                get {
                    if ( v1 == null ) v1 = new BooleanConnectorViewModel("Or 1");
                    return v1;
                }

                set {
                    v1 = value;
                }
            }

            public BooleanConnectorViewModel V2 {
                get {
                    if ( v2 == null ) v2 = new BooleanConnectorViewModel("Or 2");
                    return v2;
                }

                set {
                    v2 = value;
                }
            }
        }

        public class InternalOutputs {
            private BooleanConnectorViewModel orValue;

            public BooleanConnectorViewModel OrValue {
                get {
                    if ( orValue == null ) orValue = new BooleanConnectorViewModel("Value");
                    return orValue;
                }

                set {
                    orValue = value;
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
            this.InputConnectors.Add(inputs.V1);
            this.InputConnectors.Add(inputs.V2);
            this.OutputConnectors.Add(outputs.OrValue);
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

        public OrBooleanNodeViewModel( ) : base("Or", typeof(Boolean)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.OrValue.NoRaiseEntity = inputs.V1.Entity | inputs.V2.Entity;
            Console.WriteLine("and {0} | {1} to {2}", inputs.V1.Entity, inputs.V2.Entity, outputs.OrValue.Entity);
        }

        #endregion
    }
}
