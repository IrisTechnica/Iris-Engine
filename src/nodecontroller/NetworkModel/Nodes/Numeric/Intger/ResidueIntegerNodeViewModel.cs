using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetworkModel {
    public class ResidueIntegerNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private IntegerConnectorViewModel resi1;
            private IntegerConnectorViewModel resi2;

            public IntegerConnectorViewModel Resi1 {
                get {
                    if ( resi1 == null ) resi1 = new IntegerConnectorViewModel("Resi 1");
                    return resi1;
                }

                set {
                    resi1 = value;
                }
            }

            public IntegerConnectorViewModel Resi2 {
                get {
                    if ( resi2 == null ) resi2 = new IntegerConnectorViewModel("Resi 2");
                    return resi2;
                }

                set {
                    resi2 = value;
                }
            }
        }

        public class InternalOutputs {
            private IntegerConnectorViewModel resiValue;

            public IntegerConnectorViewModel ResiValue {
                get {
                    if ( resiValue == null ) resiValue = new IntegerConnectorViewModel("Value");
                    return resiValue;
                }

                set {
                    resiValue = value;
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
            this.InputConnectors.Add(inputs.Resi1);
            this.InputConnectors.Add(inputs.Resi2);
            this.OutputConnectors.Add(outputs.ResiValue);
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

        public ResidueIntegerNodeViewModel( ) : base("Resi", typeof(int)) {
            Initialize();
        }

        public override void Calculate( ) {
            try {
                outputs.ResiValue.NoRaiseEntity = inputs.Resi1.Entity % inputs.Resi2.Entity;
                Console.WriteLine("resi {0} % {1} to {2}", inputs.Resi1.Entity, inputs.Resi2.Entity, outputs.ResiValue.Entity);
            } catch {
                Console.WriteLine("resi {0} % {1} to error", inputs.Resi1.Entity, inputs.Resi2.Entity);
            }
        }

        #endregion
    }
}
