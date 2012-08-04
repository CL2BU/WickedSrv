using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WickedSrv___EOS_Edition.Net.Handling.IMessage;
using WickedSrv___EOS_Edition.Commons.Packet;
using WickedSrv___EOS_Edition.Commons.Encrypting;
using System.Data;
using WickedSrv___EOS_Edition.Commons.Pathfinding;

namespace WickedSrv___EOS_Edition.Net.Handling.Outgoing
{
    class PathfindMessageEvent : IMessager
    {
        public void Handle(Session Session, String data)
        {
            string All = "";
            string All2 = "";
            string[] negativ1 = data.Split('|');
            //D|T|0|#warmap:boxhitpoints|2000
            Form1.Client.ExecuteQuery("UPDATE characters SET currentx = '" + negativ1[3] + "', currenty = '" + negativ1[4].Replace("W", "") + "' WHERE userid = '" + Session.UserID + "'");
            DataTable Table = Form1.Client.ReadDataTable("SELECT * FROM collectables");
            foreach (DataRow DRow in Table.Rows)
            {
                if (negativ1[3] == DRow["x"] + "" && negativ1[4].Replace("W", "") == DRow["y"] + "")
                {
                    SFDataPacket Packet24 = new SFDataPacket(new string[] { "O", "I", DRow["id"] + "" });
                    byte[] InitDisplay24 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet24.create_message(), false) + "\0");
                    Session.Sock.NoDelay = true;
                    Session.Sock.Send(InitDisplay24);

                    SFDataPacket Packet = new SFDataPacket(new string[] { "D", "T", "0", "#warmap:box" + DRow["box"], DRow["reward"] + "" });
                    byte[] InitDisplay23 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet.create_message(), false) + "\0");
                    Session.Sock.NoDelay = true;
                    Session.Sock.Send(InitDisplay23);
                }
            }
            All2 = Pathfinder.CalculatePath(negativ1);
            SFDataPacket Packet16 = new SFDataPacket(new string[] { "S", Session.UserID + "", All.Replace("W", ""), "1" });
            byte[] InitDisplay16 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet16.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay16);
            SFDataPacket Packet17 = new SFDataPacket(new string[] { "M", Session.UserID + "", All2.Replace("W", "") });
            byte[] InitDisplay17 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet17.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay17);
            SFDataPacket Packet20 = new SFDataPacket(new string[] { "ping" });
            byte[] InitDisplay20 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet20.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay20);
            //O|I|1000251412
            //O|M|1000203203
            //M|41780102|334,-174#335,-174#336,-174#337,-174#338,-174#339,-174#340,-174#341,-174#342,-174#343,-174#344,-174#345,-174#346,-174#347,-174#348,-174#349,-174#350,-174#350,-175#351,-175#351,-176
        }
    }
}
