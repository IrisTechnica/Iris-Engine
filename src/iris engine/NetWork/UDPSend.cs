using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

        private void SendBroadcastMessage(string data) {
            // 送受信に利用するポート番号
            var port = 8000;

            // 送信データ
            var buffer = Encoding.UTF8.GetBytes(data);

            // ブロードキャスト送信
            var client = new UdpClient(port);
            client.EnableBroadcast = true;
            client.Connect(new IPEndPoint(IPAddress.Broadcast, port));
            client.Send(buffer, buffer.Length);
            client.Close();
        }
    }
}
