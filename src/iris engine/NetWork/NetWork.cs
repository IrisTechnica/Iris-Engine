using System.Threading;

namespace iris_engine.NetWork {

    /// <summary>
    /// ネットワーク管理クラス (P2P用)
    /// </summary>
    public class NetWork {

        private string IpString = "127.0.0.1";
        private int Port;
        private System.Net.IPAddress Address;
        System.Net.Sockets.UdpClient socket;
        System.Net.IPEndPoint localEP;
        
        private UDPRecv _UDPRecv;
        private UDPSend _UDPSend;

        private Thread _UDPRecvThread;
        private Thread _UDPSendThread;


        private bool _RecvThreadFlg;
        private bool _SendThreadFlg;

        public NetWork( ) {
            this._UDPRecv = new UDPRecv();
            this._UDPSend = new UDPSend();

        }
        public void InitUDP(string ip,int port = 1031) {
            //バインドするローカルIPとポート番号
            this.Address =
                System.Net.IPAddress.Parse(ip);
            this.IpString = ip;
            this.Port = port;

            //UdpClientを作成し、ローカルエンドポイントにバインドする
            this.localEP =
                new System.Net.IPEndPoint(this.Address, this.Port);

            this.socket =
                new System.Net.Sockets.UdpClient(this.localEP);

            this._UDPRecv.Init(this.socket);
            this._UDPSend.Init(this.socket);

        }
        public void ExitUDP( ) {
            this.End();
            this.socket.Close();
        }
        public void Start( ) {
            this.UDPRecvStart();
            this.UDPSendStart();
        }
        public void End( ) {
            this.UDPRecvEnd();
            this.UDPSendEnd();
        }

        //Send
        public bool UDPSend(string str,string sendip,int sendport) {
            byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(str);
            this.socket.Send(sendBytes, sendBytes.Length, sendip, sendport);

            return true;
        }
        //Recv
        public bool UDPRecvStart( ) {
            if ( this._UDPRecvThread != null )
                return false;

            this._RecvThreadFlg = true;
            this._UDPRecvThread = new Thread(new ThreadStart(UDPRecvThread));
            this._UDPRecvThread.Start();

            return true;
        }
        
        public bool UDPRecvEnd( ) {
            if ( this._UDPRecvThread == null )
                return false;
            this._RecvThreadFlg = false;
            this._UDPRecvThread.Join();
            return true;
        }
        
        //受信用スレッド
        private void UDPRecvThread( ) {
            while ( this._RecvThreadFlg ) {
                //受信処理
                if (!this._UDPRecv.Update() ) {
                    return;
                }
            }
        }

        //Send 
        public bool UDPSendStart( ) {
            if ( this._UDPSendThread != null )
                return false;

            this._SendThreadFlg = true;
            this._UDPSendThread = new Thread(new ThreadStart(UDPSendThread));
            this._UDPSendThread.Start();

            return true;
        }

        public bool UDPSendEnd( ) {
            if ( this._UDPSendThread == null )
                return false;
            this._SendThreadFlg = false;
            this._UDPSendThread.Join();
            return true;
        }

        //送信用スレッド
        private void UDPSendThread( ) {
            while ( this._SendThreadFlg ) {
                //送信処理
                if ( !this._UDPSend.Update() ) {
                    return;
                }
            }
        }

    }
}

