using System;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Zeeslag
{
    public enum Type
    {
        handshake = 1,
        ready, 
        move,      
        moveInfo,  
        quit,      
        lose,      
        win,       
        go,        
        abort,     
        reject     
    }

    public static class Net
    {
        private static Cell RecieveCell(Socket from)
        {
            Cell output = new Cell();

            //TODO change bool to int and use bitwise operator
            
            byte[] isShip   = new byte[sizeof(bool)];
            byte[] shipCode = new byte[sizeof(int)];
            byte[] number =   new byte[sizeof(int)];
            byte[] right =    new byte[sizeof(bool)];
            byte[] missed =   new byte[sizeof(bool)];
            byte[] hit =      new byte[sizeof(bool)];

            from.Receive(isShip);  output.isShip =     BitConverter.ToBoolean(isShip,0);
            from.Receive(shipCode); output.shipCode =  (ShipCode)BitConverter.ToInt32(shipCode, 0);
            from.Receive(number); output.number =      BitConverter.ToInt32(number, 0);
            from.Receive(right); output.right =        BitConverter.ToBoolean(right, 0);
            from.Receive(missed); output.missed =      BitConverter.ToBoolean(missed, 0);
            from.Receive(hit); output.hit =            BitConverter.ToBoolean(isShip, 0);

            return output;
        }

        public static void ReceiveMove(Socket from, out int x, out int y)
        {
            byte[] bx = new byte[sizeof(int)];
            byte[] by = new byte[sizeof(int)];

            from.Receive(bx); x = BitConverter.ToInt32(bx,0);
            from.Receive(by); y = BitConverter.ToInt32(by,0);
        }

        public static void ReceiveMoveInfo(Socket from,out int x,out int y, out bool destroyed, out Cell c)
        {
            byte[] bd = new byte[sizeof(bool)];
            byte[] bx = new byte[sizeof(int)];
            byte[] by = new byte[sizeof(int)];

            from.Receive(bx); x = BitConverter.ToInt32(bx, 0);
            from.Receive(by); y = BitConverter.ToInt32(by, 0);
            from.Receive(bd); destroyed = BitConverter.ToBoolean(bd, 0);

            c = RecieveCell(from);
        }

        public static Type ReceiveType(Socket from)
        {
            byte[] b = new byte[sizeof(int)];
            from.Receive(b);
            return (Type)BitConverter.ToInt32(b,0);
        }

        private static void SendCell(Socket to, Cell c)
        {

            to.Send(BitConverter.GetBytes(c.isShip));
            to.Send(BitConverter.GetBytes((int)c.shipCode));
            to.Send(BitConverter.GetBytes(c.number));
            to.Send(BitConverter.GetBytes(c.right));
            to.Send(BitConverter.GetBytes(c.missed));
            to.Send(BitConverter.GetBytes(c.hit));
        }

        public static void SendMove(Socket to, int x, int y)
        {
            to.Send(BitConverter.GetBytes((int)Type.move));
            to.Send(BitConverter.GetBytes(x));
            to.Send(BitConverter.GetBytes(y));
        }

        public static void SendMoveInfo(Socket to,int x,int y,bool destroyed, Cell c)
        {
            to.Send(BitConverter.GetBytes((int)Type.moveInfo));

            to.Send(BitConverter.GetBytes(x));
            to.Send(BitConverter.GetBytes(y));
            to.Send(BitConverter.GetBytes(destroyed));
            SendCell(to, c);
        }

        public static void SendType(Socket to,Type type)
        {
            to.Send(BitConverter.GetBytes((int)type));
        }
    }
}