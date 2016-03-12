using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkModel {
    public class SubIntegerNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private IntegerConnectorViewModel sub1;
            private IntegerConnectorViewModel sub2;

            public IntegerConnectorViewModel Sub1 {
                get {
                    if ( sub1 == null ) sub1 = new IntegerConnectorViewModel("Sub 1");
                    return sub1;
                }

                set {
                    sub1 = value;
                }
            }

            public IntegerConnectorViewModel Sub2 {
                get {
                    if ( sub2 == null ) sub2 = new IntegerConnectorViewModel("Sub 2");
                    return sub2;
                }

                set {
                    sub2 = value;
                }
            }
        }

        public class InternalOutputs {
            private IntegerConnectorViewModel subValue;

            public IntegerConnectorViewModel SubValue {
                get {
                    if ( subValue == null ) subValue = new IntegerConnectorViewModel("Value");
                    return subValue;
                }

                set {
                    subValue = value;
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
            this.InputConnectors.Add(inputs.Sub1);
            this.InputConnectors.Add(inputs.Sub2);
            this.OutputConnectors.Add(outputs.SubValue);
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

        public SubIntegerNodeViewModel( ) : base("Sub", typeof(int)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.SubValue.NoRaiseEntity = inputs.Sub1.Entity + inputs.Sub2.Entity;
            Console.WriteLine("sub {0} - {1} to {2}", inputs.Sub1.Entity, inputs.Sub2.Entity, outputs.SubValue.Entity);
        }

        #endregion
    }
}
