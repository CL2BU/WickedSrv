using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using WickedSrv___EOS_Edition.Commons.Enums;
using System.Net;
using System.Windows.Forms;

namespace WickedSrv___EOS_Edition.Net
{
    public class SessionManager
    {
        public static Socket mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Dictionary<Socket, Session> Sessions = new Dictionary<Socket, Session>();
        public static int CurrID = 0;
        public Form1 Form = null;
        public TextBox txt = null;
        public SessionManager(Form1 MainForm)
        {
            this.Form = MainForm;
            this.txt = this.Form.textBox1;
        }

        public delegate void PrintText_CallBack(string what);

        public void Print(string what)
        {
            if (this.txt.InvokeRequired)
            {
                this.txt.Invoke(new PrintText_CallBack(Print), new string[] { what });
            }
            else
            {
                this.txt.Text += what + Environment.NewLine;
                this.txt.SelectionStart = this.txt.Text.Length;
                this.txt.ScrollToCaret();
            }
        }

        public Serializer Serialize(string Host, int Port)
        {
            try
            {
                mainSock.Bind(new IPEndPoint(IPAddress.Any, Port));
                mainSock.Listen(1000);
                mainSock.Blocking = false;

                StartAccept();
                return Serializer.Succeed;
            }
            catch
            {
                return Serializer.Failed;
            }
        }

        public void StartAccept()
        {
            try
            {
                mainSock.BeginAccept(new AsyncCallback(Accept), mainSock);
            }
            catch { }
        }

        public void Accept(IAsyncResult Iar)
        {
            try
            {
                Socket newSock = mainSock.EndAccept(Iar);
                int newID = CurrID++;
                Session newSession = new Session(newID, newSock);
                Sessions.Add(newSock, newSession);
                newSession.StartReceive();
                StartAccept();
            }
            catch { }
        }

        public static void Send2All(byte[] data)
        {
            foreach (Session S in Sessions.Values)
            {
                if (S.Sock != null)
                {
                    S.Sock.NoDelay = true;
                    S.Sock.Send(data);
                }
            }
        }
    }
}
