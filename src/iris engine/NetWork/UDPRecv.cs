using System;
using System.Collections.Generic;
using System.Linq;


namespace iris_engine.NetWork {

    //UDP 1031
    //TCP 1032


    class UDPRecv {
        System.Net.Sockets.UdpClient socket;
        public UDPRecv( ) {
            this.socket = null;
        }
        public void Init(System.Net.Sockets.UdpClient socket) {
            this.socket = socket;
        }

        public bool Update( ) {
            if ( this.socket == null )
                return false;
            //受信したデータをテキストブロックに追加していく

            //データを受信する
            System.Net.IPEndPoint remoteEP = null;
            byte[] rcvBytes = this.socket.Receive(ref remoteEP);

            //データを文字列に変換する
            string rcvMsg = System.Text.Encoding.UTF8.GetString(rcvBytes);

            //ここに受信したデータを処理（受信データリストにプッシュ or 処理する)
            



            return true;
        }
    }
}
