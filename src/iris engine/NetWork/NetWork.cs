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
    public class NetWork {
        
        private List<NetWorkUDPConnector> connector;     //

        //private NetWorkUDPBroadcast Client;
        public NetWork( ) {

        }
        public bool Init( ) {
            ////リスト作成用ブロードキャストの作成
            //this.Client = new NetWorkUDPBroadcast();
            //this.Client.Create(IPAddress.Broadcast.ToString(), 50000,true,true);
            //
            //this.Client.StartRecv();
            //this.Client.Update();


            return true;
        }

        public bool Connect(string ip,string port) {

            return true;
        }
        
        //ネットワークの状態を更新する
        private void Update( ) {

        }
        public bool Close( ) {

            foreach(var v in connector ) {
                v.Close();
            }

            return true;
        }
    }
}

