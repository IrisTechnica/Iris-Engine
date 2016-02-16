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

        public void Broadcast( ) {
            

        }
        public void ReceiveCallback(IAsyncResult ar) {
            System.Net.Sockets.UdpClient udp =
        (System.Net.Sockets.UdpClient)ar.AsyncState;

            //非同期受信を終了する
            System.Net.IPEndPoint remoteEP = null;
            byte[] rcvBytes;
            try {
                rcvBytes = udp.EndReceive(ar, ref remoteEP);
            } catch ( System.Net.Sockets.SocketException ex ) {
                Console.WriteLine("受信エラー({0}/{1})",
                    ex.Message, ex.ErrorCode);
                return;
            } catch ( ObjectDisposedException ex ) {
                //すでに閉じている時は終了
                Console.WriteLine("Socketは閉じられています。");
                return;
            }

            //データを文字列に変換する
            string rcvMsg = System.Text.Encoding.UTF8.GetString(rcvBytes);

            //受信したデータと送信者の情報をRichTextBoxに表示する
            string displayMsg=string.Format("[{0} ({1})] > {2}",
            remoteEP.Address, remoteEP.Port, rcvMsg);
            Console.WriteLine(displayMsg);
            //再びデータ受信を開始する
            udp.BeginReceive(ReceiveCallback, udp);
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
