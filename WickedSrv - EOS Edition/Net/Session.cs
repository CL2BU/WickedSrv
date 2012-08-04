using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using WickedSrv___EOS_Edition.Commons.Encrypting;
using WickedSrv___EOS_Edition.Commons.Packet;
using System.Data;
using WickedSrv___EOS_Edition.Commons.Pathfinding;
using WickedSrv___EOS_Edition.Net.Handling;

namespace WickedSrv___EOS_Edition.Net
{
    public class Session
    {
        public int ID;
        public string IP;
        public Socket Sock;
        public byte[] Buff = new byte[4096];
        public int UserID = 0;
        public DataRow Row;

        public Session(int ID, Socket Sock)
        {
            this.ID = ID;
            this.Sock = Sock;
            this.IP = Sock.RemoteEndPoint.ToString().Split(':')[0];
        }

        public void StartReceive()
        {
            try
            {
                this.Sock.BeginReceive(Buff, 0, Buff.Length, SocketFlags.None, new AsyncCallback(Recv), this.Sock);
            }
            catch { }
        }

        public void Recv(IAsyncResult Iar)
        {
            try
            {
                if (this.Sock.Connected)
                {
                    int TotalBytes = this.Sock.EndReceive(Iar);
                    if (TotalBytes > 0)
                    {
                        string data = Encoding.Default.GetString(this.Buff, 0, TotalBytes);
                        if (data.Contains("<policy"))
                        {
                            string Data2 = "<?xml version=\"1.0\"?>" + "\r\n" + "<!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">" + "\r\n" + "<cross-domain-policy>" + "\r\n" + "   <allow-access-from domain=\"*\" to-ports=\"*\" />" + "\r\n" + "</cross-domain-policy>\0";
                            byte[] dataBytes = Encoding.Default.GetBytes(Data2);
                            this.Sock.NoDelay = true;
                            this.Sock.Send(dataBytes);
                            ////Form1.getManager().Print("[" + this.IP + "] Sended policy");
                        }
                        else
                        {
                            Form1.getManager().Print(Encoders.DecryptMsg(data, true));
                            if (Encoders.DecryptMsg(data, true) != "")
                            {
                                PacketHandler.HandlePacket(this, Encoders.DecryptMsg(data, true));
                            }
                        }
                    }
                }
                else
                {
                    this.Sock.Close();
                    this.Sock.Dispose();
                    SessionManager.Sessions.Remove(this.Sock);
                }
                StartReceive();
            }
            catch(Exception Ex)
            {
                Form1.getManager().Print(Ex.ToString());
            }
        }
    }
}
