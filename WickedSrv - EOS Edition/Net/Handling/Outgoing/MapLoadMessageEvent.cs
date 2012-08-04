using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WickedSrv___EOS_Edition.Net.Handling.IMessage;
using WickedSrv___EOS_Edition.Commons.Encrypting;
using WickedSrv___EOS_Edition.Commons.Packet;

namespace WickedSrv___EOS_Edition.Net.Handling.Outgoing
{
    class MapLoadMessageEvent : IMessager
    {
        public void Handle(Session Session, String data)
        {
            string[] Datas = data.Split('|');
            Session.UserID = int.Parse(Datas[1].Replace("W", ""));

            Session.Row = Form1.Client.ReadDataRow("SELECT * FROM characters WHERE userid = '" + Session.UserID + "'");


            SFDataPacket Packet1 = new SFDataPacket(new string[] { "B", Session.Row["mapid"] + "", Session.Row["mapname"] + "" });
            byte[] InitDisplay = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet1.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay);
        }
    }
}
