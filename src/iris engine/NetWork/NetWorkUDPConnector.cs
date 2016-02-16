using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace iris_engine.NetWork {
    public class NetWorkUDPConnector {

        private string IpString = "";
        private int Port;
        private System.Net.IPAddress Address;
        protected System.Net.Sockets.UdpClient socket;
        private System.Net.IPEndPoint IPEP;

        public NetWorkUDPConnector( ) {
            this.Address = null;
            this.socket = null;
            this.IPEP = null;
        }

        public bool Create(string ip, int port, bool createSocket = true,bool Broudcast = false) {
            if (
                this.socket != null
                || this.Address != null
                || !CheckIPAddress(ip)
                || !CheckPort(port) ) {
                return false;
            }

            this.IpString = ip;
            this.Port = port;
            if ( createSocket )
                return true;
            if ( Broudcast )
                return CreateBroudcastSocket();
            return CreateSocket();
        }
        public bool Create(string ip, string port, bool createSocket = true) {
            try {
                return this.Create(ip, int.Parse(port), createSocket);
            } catch {
                return false;
            }
        }
        private bool CreateBroudcastSocket( ) {
            this.socket = new UdpClient(this.Port);
            this.socket.EnableBroadcast = true;
            this.socket.Connect(new IPEndPoint(IPAddress.Broadcast, this.Port ));
            this.socket.Close();
            return true;
        }
        public bool CreateSocket( ) {
            try {
                this.IPEP =
                    new System.Net.IPEndPoint(this.Address, this.Port);
                this.socket =
                    new System.Net.Sockets.UdpClient(this.IPEP);

            } catch {
                return false;
            }
            return true;
        }
        public void Close( ) {
            this.socket.Close();
        }

        public bool StartRecv( ) {
            try { 
                this.socket.BeginReceive(ReceiveCallback, this.socket);
            } catch {
                return false;
            }
            return true;
        }
        public bool Send(byte[] data) {
            if ( this.socket == null )
                return false;
            try {
                this.socket.Send(data, data.Length);
            }catch {
                return false;
            }
            return true;
        }

        virtual public void Update( ) {

        }
        //データを受信した時
        virtual public void ReceiveCallback(IAsyncResult ar) {
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

        //    //受信したデータと送信者の情報をRichTextBoxに表示する
        //    string displayMsg=string.Format("[{0} ({1})] > {2}",
        //remoteEP.Address, remoteEP.Port, rcvMsg);
        //    RichTextBox1.BeginInvoke(
        //        new Action<string>(ShowReceivedString), displayMsg);

            //再びデータ受信を開始する
            udp.BeginReceive(ReceiveCallback, udp);
        }

        //入力チェック
        private bool CheckPort(int port) {
            if ( port < 0 || port > 65535 ) {
                return false;
            }
            return true;
        }
        private bool CheckIPAddress(string ip) {

            int count = ip.Length - ip.Replace(".".ToString(), "").Length;

            if ( count != 3 ) {
                return false;
            }

            string[] ipSplitData = ip.Split('.');

            foreach ( string data in ipSplitData ) {
                try {
                    int.Parse(data);
                } catch {
                    return false;
                }

                if ( int.Parse(data) < 0 || int.Parse(data) > 255 ) {
                    return false;
                }
            }
            return true;
        }
    }
}
