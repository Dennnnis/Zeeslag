using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace Zeeslag
{
    public partial class Setup : Form
    {
        public delegate void StartDelegate();

        bool hosted = false;
        TcpListener TCP;

        public Setup()
        {
            InitializeComponent();
        }

        private void SimpleMenuReset()
        {
            if (hosted) { TCP.Stop(); }

            waitingDialog.Visible = false;
            hostButton.Enabled = true;
            connectButton.Enabled = true;
            Connection.amIHost = false;
            hosted = false;
        }

        private void StartGame()
        {
            Hide();
            Designer dg = new Designer();
            dg.ShowDialog();
            Show();

            SimpleMenuReset();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            hostButton.Enabled = false;
            connectButton.Enabled = false;


            if (short.TryParse(textBox2.Text, out short port))
            {
                try
                {
                    if (Connection.Connect(textBox1.Text, port))
                    {
                        Console.WriteLine("Handshake send!");
                        Connection.socket.ReceiveTimeout = 4000;
                        if (Net.ReceiveType(Connection.socket) == Type.handshake)
                        {
                            Console.WriteLine("Received response!");
                            Connection.socket.ReceiveTimeout = 0;
                            StartGame();
                        }
                        else
                        {
                            MessageBox.Show("Server accepteert handshake niet", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kan de andere speler niet vinden", "Error");
                        SimpleMenuReset();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Server reageert niet!", "Error");
                    SimpleMenuReset();
                }
            }
            else
            {
                MessageBox.Show("Check je port", "Error");
            }
        }

        private void Waiting(object port)
        {
            try
            {
                TCP = new TcpListener(System.Net.IPAddress.Any, (short)port);
                TCP.Start();

                Connection.socket = TCP.AcceptSocket();

                if (Net.ReceiveType(Connection.socket) != Type.handshake) throw new Exception();
                Console.WriteLine("Handshake received!");

                Net.SendType(Connection.socket, Type.handshake);
                Console.WriteLine("Send response");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Invoke(new StartDelegate(SimpleMenuReset));
                return;
            }

            Invoke(new StartDelegate(StartGame));
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            if (short.TryParse(textBox2.Text, out short port))
            {
                waitingDialog.Visible = true;
                hostButton.Enabled = false;
                connectButton.Enabled = false;

                hosted = true;
                Thread t = new Thread(new ParameterizedThreadStart(Waiting));
                Connection.amIHost = true;
                t.Start(port);
            }
            else
            {
                MessageBox.Show("Check je port", "Error");
            }
        }
    }
}
