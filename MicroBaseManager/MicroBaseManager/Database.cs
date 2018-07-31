using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager
{
    public static class Database
    {
        public static Socket MainConnection { get; private set; }

        public static Connection CurrentConnection { get; private set; }

        public static object CheckConnection(Connection conn)
        {
            string HOST = conn.GetConnect();
            int PORT = conn.GetPort();
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = Dns.GetHostAddresses(HOST)[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);

                Socket socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remoteEP);

                GetDataStringWithSocket(socket);
                Answer ans = SendGetAnswerWithSocket(socket, "VISUAL");
                socket.Close();
                if (ans.Info != Inf.OK)
                    throw new Exception("На порту используется другой сервер");
               
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static Socket GetSocketFromConnect(Connection conn)
        {
            string HOST = conn.GetConnect();
            int PORT = conn.GetPort();
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = Dns.GetHostAddresses(HOST)[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);

            Socket sock;
            sock = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
            //sock.Connect(remoteEP);
            IAsyncResult result = sock.BeginConnect(HOST, PORT, null, null);

            bool success = result.AsyncWaitHandle.WaitOne(3000, true);

            if (sock.Connected)
            {
                sock.EndConnect(result);
            }
            else
            {
                // NOTE, MUST CLOSE THE SOCKET

                sock.Close();
                throw new ApplicationException("Не удалось подключиться к серверу");
            }
            GetDataStringWithSocket(sock);
            return sock;
        }

        public static bool Connect(Connection conn)
        {
            try
            {
                MainConnection = GetSocketFromConnect(conn);
                if (MainConnection == null)
                    return false;
                Answer ans = SendGetAnswerWithSocket(MainConnection, "VISUAL");
                if (ans.Info != Inf.OK)
                {
                    MainConnection.Close();
                    throw new Exception("На порту используется другой сервер");
                }
                MainConnection.ReceiveTimeout = 2000;
                CurrentConnection = conn;
                return true;
            }
            catch (Exception ex)
            {
                MainConnection = null;
                MessageBox.Show(String.Format("Произошла ошибка:\n{0}", ex.Message), "Соединение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void Disconnect()
        {
            try
            {
                CurrentConnection = null;
                MainConnection.Close();
                MainConnection = null;
            }
            catch { }
        }

        public static long CheckConnectionPing()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SendGetAnswer("ME");
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public static void Reconnection()
        {
            while (MainConnection == null)
            {
                try
                {
                    if (Database.CurrentConnection == null)
                        return;
                    Socket sock = GetSocketFromConnect(Database.CurrentConnection);
                    if (MainConnection == null)
                    {
                        MainConnection = sock;
                    }
                    else
                    {
                        try
                        {
                            sock.Disconnect(false);
                        }
                        catch { }
                        return;
                    }
                    Answer ans = SendGetAnswerWithSocket(MainConnection, "VISUAL");
                    if (ans.Info != Inf.OK)
                    {
                        MainConnection.Close();
                        throw new Exception("На порту используется другой сервер");
                    }
                    MainConnection.ReceiveTimeout = 5000;
                }
                catch
                {}
            }
        }

        private static Thread ReconnectionThread;
        public static void TryingReconnection()
        {
            if (ReconnectionThread == null || ReconnectionThread.ThreadState != ThreadState.Running)
            {
                ReconnectionThread = new Thread(new ThreadStart(Database.Reconnection));
                ReconnectionThread.Start();
            }
        }

        public static byte[] buffer = new byte[1048576];
        public static String GetDataStringWithSocket(Socket socket)
        {
            StringBuilder str = new StringBuilder();
            int count;
            lock (buffer)
            {
                while (true)
                {
                    try
                    {
                        count = socket.Receive(buffer);
                        str.Append(Encoding.UTF8.GetString(buffer, 0, count));
                        if (socket.Available <= 0) break;
                    }
                    catch (SocketException ex)
                    {
                        if (ex.ErrorCode == 10060)
                            break;
                        if (ex.ErrorCode == 10054)
                        {
                            if (socket == MainConnection)
                            {
                                MainConnection = null;
                                TryingReconnection();
                            }
                        }
                        MessageBox.Show(ex.Message);
                        break;
                    }
                    catch (NullReferenceException)
                    {
                        TryingReconnection();
                        return "<DISCONNECTED>";
                    }
                }
            }
            return str.ToString().TrimEnd(new char[] { '\n' }).TrimEnd(new char[] { '\r' });
        }

        public static bool SendDataStringWithSocket(Socket socket, string data)
        {
            data += "\r\n";
            try
            {
                socket.Send(Encoding.UTF8.GetBytes(data));
                return true;
            }
            catch (SocketException)
            {
                if (socket == MainConnection)
                {
                    TryingReconnection();
                    MainConnection = null;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                TryingReconnection();
                return false;
            }
        }

        public static bool SendDataString(string data)
        {
            return SendDataStringWithSocket(MainConnection, data);
        }

        public static String GetDataString()
        {
            return GetDataStringWithSocket(MainConnection);
        }

        public static Answer GetAnswerWithSocket(Socket socket)
        {
            return new Answer(GetDataStringWithSocket(socket));
        }

        public static Answer SendGetAnswerWithSocket(Socket socket, params string[] data)
        {
            if (socket==null)
                return new Answer("<DISCONNECTED>");
            if (data.Length == 0)
                return new Answer("<NULL>");
            Answer ans = null;
            lock (socket)
            {
                foreach (string str in data)
                {
                    SendDataStringWithSocket(socket, str);
                    ans = GetAnswerWithSocket(socket);
                }
                return ans;
            }
        }

        public static Answer GetAnswer()
        {
            return GetAnswerWithSocket(MainConnection);
        }

        public static Answer SendGetAnswer(params string[] data)
        {
            return SendGetAnswerWithSocket(MainConnection, data);
        }
    }
}
