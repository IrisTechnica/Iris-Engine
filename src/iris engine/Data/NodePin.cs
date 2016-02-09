using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Data {
    class NodePin {
        //接続成功時trueを返す
        public bool AttachPin(NodePin pin) {
            if(this._ioType != pin._ioType && this._dataType == pin._dataType) {
                this.pin = pin;
                pin.pin = this;
                return true;
            }
            return false;
        }
        //ピンの接続を解除(双方の接続を解除)
        public void Remove( ) {
            this.pin.pin = null;
            this.pin = null;
        }
        //ピンにデータを送る
        public bool OutPut( ) {
            if(this.pin == null ) {
                return false;
            }
            return this.pin.InPut(this.data);
        }
        //ピンからデータを取得する
        public bool InPut( NodeData data) {
            this.data = data;
            return true;
        }
        public NodeIOType _ioType { get; set; }
        public NodeDataType _dataType { get; set; }
        public NodePin pin;
        public NodeData data;
    }
}
