﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NetworkModel {
    public class ConstantColorNodeViewModel : AbstractNodeViewModel {
        #region Internal Classes [None Internal constraints]

        public class InternalOutputs {
            private ColorConnectorViewModel constantValue;

            public ColorConnectorViewModel ConstantValue {
                get {
                    if ( constantValue == null ) constantValue = new ColorConnectorViewModel("Value");
                    return constantValue;
                }

                set {
                    constantValue = value;
                }
            }
        }

        #endregion

        #region Private Data Members

        private InternalOutputs outputs = new InternalOutputs();

        #endregion

        #region Private Methods

        private void Initialize( ) {
            this.OutputConnectors.Add(outputs.ConstantValue);
            // ヘッダなしのコネクタにする
            // コネクタを追加した後で設定すること
            this.SingleConnectorType = true;
        }

        #endregion

        #region Public Properties

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

        public ConstantColorNodeViewModel( ) : base("Constant", typeof(ColorData)) {
            Initialize();
        }


        public override void Calculate( ) {
            // donot calculate
            Console.WriteLine("constant value : " + outputs.ConstantValue.Entity.ToString());
        }

        #endregion

    }
}
