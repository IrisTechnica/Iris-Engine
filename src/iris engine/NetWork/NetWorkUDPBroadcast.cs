using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.NetWork {
    public  class NetWorkUDPBroadcast : NetWorkUDPConnector {

        public List<IPEndPoint> ClientList;
        public NetWorkUDPBroadcast( ) {

        }
        public override void Update( ) {
            string str = "List";//仮
            byte[] data = Encoding.UTF8.GetBytes(str);
            this.Send(data);
        }
        //データを受信した時
        public override void ReceiveCallback(IAsyncResult ar){
            System.Net.Sockets.UdpClient udp =
        (System.Net.Sockets.UdpClient)ar.AsyncState;

            //非同期受信を終了する
            IPEndPoint remoteEP = null;
            byte[] rcvBytes;
            try {
                rcvBytes = udp.EndReceive(ar, ref remoteEP);
            } catch ( System.Net.Sockets.SocketException ex ) {
                Console.WriteLine("受信エラー({0}/{1})",
                    ex.Message, ex.ErrorCode);
                return;
            } catch {
                Console.WriteLine("Socketは閉じられています。");
                return;
                //すでに閉じている時は終了
            }

            //データを文字列に変換する
            string rcvMsg = Encoding.UTF8.GetString(rcvBytes);
            if(rcvMsg == "Client" ) {
                ClientList.Add(remoteEP);
            }
            //    //受信したデータと送信者の情報をRichTextBoxに表示する
            //    string displayMsg=string.Format("[{0} ({1})] > {2}",
            //remoteEP.Address, remoteEP.Port, rcvMsg);
            //    RichTextBox1.BeginInvoke(
            //        new Action<string>(ShowReceivedString), displayMsg);

            //再びデータ受信を開始する
            udp.BeginReceive(ReceiveCallback, udp);
        }
    }
}
