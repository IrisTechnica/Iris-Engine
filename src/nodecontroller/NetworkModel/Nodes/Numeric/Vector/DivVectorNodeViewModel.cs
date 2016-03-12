using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace NetworkModel {
    public class DivVectorNodeViewModel : AbstractNodeViewModel {

        #region Internal Classes [None Internal constraints]

        public class InternalInputs {
            private VectorConnectorViewModel div1;
            private VectorConnectorViewModel div2;

            public VectorConnectorViewModel Div1 {
                get {
                    if ( div1 == null ) div1 = new VectorConnectorViewModel("Div 1");
                    return div1;
                }

                set {
                    div1 = value;
                }
            }

            public VectorConnectorViewModel Div2 {
                get {
                    if ( div2 == null ) div2 = new VectorConnectorViewModel("Div 2");
                    return div2;
                }

                set {
                    div2 = value;
                }
            }
        }

        public class InternalOutputs {
            private VectorConnectorViewModel divValue;

            public VectorConnectorViewModel DivValue {
                get {
                    if ( divValue == null ) divValue = new VectorConnectorViewModel("Value");
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

        public DivVectorNodeViewModel( ) : base("Div", typeof(Vector3)) {
            Initialize();
        }

        public override void Calculate( ) {
            outputs.DivValue.NoRaiseEntity = inputs.Div1.Entity * inputs.Div2.Entity;
            Console.WriteLine("div {0} * {1} to {2}", inputs.Div1.Entity, inputs.Div2.Entity, outputs.DivValue.Entity);
        }

        #endregion
    }
}
