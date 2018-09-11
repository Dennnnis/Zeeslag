using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Zeeslag
{
    public static class Connection
    {
        public static Socket socket;
        public static bool amIHost = false;

        public static bool Connect(string host,int port)
        {
            socket = new Socket(SocketType.Stream,ProtocolType.Tcp);
            try
            {
                socket.Connect(host, port);
                Net.SendType(socket, Type.handshake);
            }
            catch (Exception) { return false; }

            return true;
        }
    }
}
