using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeeslag
{
    public partial class Popup : Form
    {
        public int timer = 0;
        public int until = 0;

        public Popup(string msg,int time)
        {
            InitializeComponent();
            until = time;
            label1.Text = msg;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer >= until)
                Close();
        }
    }
}
