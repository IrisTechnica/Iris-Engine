using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace iris_engine.NetWork {
    public class NetWorkUDPConnector {
        //スレッド回り
        private Thread sendThread;
        private bool closeSendThreadFlg;

        private UdpClient recvSocket;
        private UdpClient sendSocket;
        private IPEndPoint sendIP;

        protected List<byte[]> sendQue;
        protected List<byte[]> recvQue;

        public delegate bool RecvData(byte[] data);

        public NetWorkUDPConnector( ) {
            this.sendSocket = null;
            this.recvSocket = null;

            this.sendQue = new List<byte[]>();
            this.recvQue = new List<byte[]>();
        }
        ~NetWorkUDPConnector( ) {
            this.Close();
        }
        public bool Create(string ip, int port, int serverport) {
            if ( !CheckIPAddress(ip)
                || !CheckPort(port) ) {
                return false;
            }
            return CreateSocket(ip, port, serverport);
        }
        public bool Create(string ip, string port, string serverport) {
            try {
                return this.Create(ip, int.Parse(port), int.Parse(serverport));
            } catch {
                return false;
            }
        }

        public bool CreateSocket(string ip, int port, int recvport) {
            try {
                //ソケットの生成
                CreateRecvUDPSocket(recvport);
                CreateSendUDPSocket(ip, port);

            } catch {
                return false;
            }
            return true;
        }

        public bool CreateSendUDPSocket(string ip, int port) {
            if ( this.sendSocket != null )
                return false;
            try {
                this.sendIP = new IPEndPoint(IPAddress.Parse(ip), port);
                this.sendSocket = new System.Net.Sockets.UdpClient();

                //送信用スレッドの生成
                this.closeSendThreadFlg = false;
                this.sendThread = new Thread(SendThread);
                this.sendThread.Start();
            } catch {
                return false;
            }
            return true;
        }
        public bool CreateRecvUDPSocket(int port) {
            if ( this.recvSocket != null )
                return false;
            try {
                this.recvSocket = new System.Net.Sockets.UdpClient(port);
                this.recvSocket.DontFragment = true;
                this.recvSocket.EnableBroadcast = true;
                
                //非同期受信
                this.recvSocket.BeginReceive(ReceiveCallback, this.recvSocket);
            } catch {
                return false;
            }
            return true;
        }

        public void Close( ) {
            this.closeSendThreadFlg = true;
            this.CloseSendSocket();
            this.CloseRecvSocket();
        }
        public void CloseSendSocket( ) {
            if ( this.sendSocket != null ) {
                this.sendSocket.Close();
            }
            this.sendSocket = null;
        }
        public void CloseRecvSocket( ) {
            if ( this.recvSocket != null ) {
                this.recvSocket.Close();
            }
            this.recvSocket = null;
        }


        public void SendThread( ) {
            do {
                if ( this.sendQue.Count != 0 ) {
                    lock ( this.sendQue ) {
                        //すべて送信した後キューの中身をクリア
                        foreach ( var v in this.sendQue ) {
                            this.Send(v);
                        }
                        this.sendQue.Clear();
                    }
                }
            } while ( !this.closeSendThreadFlg );
        }
        public bool Send(byte[] data) {
            if ( this.sendSocket == null )
                return false;
            try {
                this.sendSocket.Send(data, data.Length, this.sendIP);
            } catch {
                return false;
            }
            return true;
        }
        public bool AddSendQue(byte[] data) {
            lock( this.sendQue ) {
                this.sendQue.Add(data);
            }
            return true;
        }
        

        /// <summary>
        /// 同期受信を行い受信データを返す
        /// </summary>
        /// <returns></returns>
        public void RecvAndAddQue( ) {
            if ( this.recvSocket.Available > 0 ) {
                IPEndPoint remoteEP = null;
                byte[] recvdata = this.recvSocket.Receive(ref remoteEP);
                this.AddRecvQue(recvdata);
            }
        }

        private void ReceiveCallback(IAsyncResult AR) {
            // ソケット受信
            System.Net.IPEndPoint ipAny = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
            Byte[] dat = recvSocket.EndReceive(AR, ref ipAny);
            AddRecvQue(dat);
            // ソケット非同期受信(System.AsyncCallback)
            recvSocket.BeginReceive(ReceiveCallback, recvSocket);
        }
    
        public bool AddRecvQue(byte[] data) {
            lock ( this.recvQue ) {
                this.recvQue.Add(data);
            }
            return true;
        }
        public List<byte[]> GetRecvQue( ) {
            List<byte[]> data = null;
            lock( this.recvQue ) { 
                data = this.recvQue;
                this.recvQue = new List<byte[]>();
            }
            return data;
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
        private string getIPAddress( ) {
            string ipaddress = "";
            IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());

            foreach ( IPAddress ip in ipentry.AddressList ) {
                if ( ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ) {
                    ipaddress = ip.ToString();
                    break;
                }
            }
            return ipaddress;
        }
    }
}
