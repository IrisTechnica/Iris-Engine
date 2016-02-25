//
//  Broadcast Port 5000
//

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace iris_engine.NetWork {

    /// <summary>
    /// ネットワーク管理クラス 
    /// </summary>
    public sealed class NetWork {
        private static NetWork _network = new NetWork();

        private static NetWorkUDPConnector UDPSocket;
        
        public static NetWork GetInstance( ) {
            return _network;
        }
        public NetWork( ) {

        }
        ~NetWork( ) {
            this.Close();
        }
        public bool Init( ) {
            if ( UDPSocket != null )
                UDPSocket.Close();
            UDPSocket = null;
            return true;
        }

        public bool Connect(string ip,string port,string recvport) {
            if ( UDPSocket != null )
                return false;
            UDPSocket = new NetWorkUDPConnector();
            UDPSocket.Create(ip, port, recvport);
            return true;
        }
        
        public bool Close( ) {
            if(UDPSocket != null)
                UDPSocket.Close();
            UDPSocket = null;
            return true;
        }
        public bool Send(byte[] data) {
            if ( UDPSocket == null )
                return false;
            UDPSocket.AddSendQue(data);
            return true;
        }
        public List<byte[]> Recv( ) {
            return UDPSocket.GetRecvQue();
        }
    }
}

