using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WickedSrv___EOS_Edition.Net;
using WickedSrv___EOS_Edition.Commons.Encrypting;
using WickedSrv___EOS_Edition.Commons.MySQL;
using WickedSrv___EOS_Edition.Net.Handling;

namespace WickedSrv___EOS_Edition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Form1 self = new Form1();
        internal static SessionManager SManager;
        public static SqlClient Client;
        private void primeButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
        public static SessionManager getManager()
        {
            return SManager;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SManager = new SessionManager(this);
            getManager().Serialize("", 90);

            SqlClient CClient = new SqlClient();

            Client = CClient.GetClient();

            PacketHandler.GenerateAll();
        }
        private void primeButton2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                textBox3.Text = Encoders.DecryptMsg(textBox2.Text, true);
            }
        }
    }
}
