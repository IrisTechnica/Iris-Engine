using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.NetWork {
    class UDPSend {
        System.Net.Sockets.UdpClient socket;
        public UDPSend( ) {
            this.socket = null;
        }
        public void Init(System.Net.Sockets.UdpClient socket) {
            this.socket = socket;
        }
        public bool Update( ) {
            if ( this.socket == null )
                return false;



            return true;
        }
    }
}
