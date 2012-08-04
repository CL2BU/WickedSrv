using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WickedSrv___EOS_Edition.Net.Handling.IMessage;
using WickedSrv___EOS_Edition.Commons.Packet;
using WickedSrv___EOS_Edition.Commons.Encrypting;
using System.Data;

namespace WickedSrv___EOS_Edition.Net.Handling.Outgoing
{
    class UserLoginMessageEvent : IMessager
    {
        public void Handle(Session Session, String data)
        {
            //E|S|33598472|0|283|2|3.9000001|246|68.67158508|246,69#246,70#246,71#246,72#246,73#246,74#246,75#246,76#246,77#246,78#246,79#246,80#246,81#246,82#246,83#246,84#246,85|miki091954|hur|87320|88800|0|150000|300|426|0|0|0|15|1|7,0,0,0||0|fl=0#ns=0#hr=10.0#bhp=88800
            //O|S|1000433879|1|14508410|#warmap:killpirategold|1595!4
            //D|M|72787|77000|150000|150000|37868|28250|0|310|3.21290898|70|21|5,9559#51,44215#101,2293|18,29#20,7722#75,1|1|0|1|0|4|fl=0#ns=0#hr=10.0
            Form1.getManager().Print("[" + Session.IP + "] User: " + Session.UserID + " has been logged in.");
            SFDataPacket Packet1 = new SFDataPacket(new string[] { "ping" });
            byte[] InitDisplay = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet1.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay);

            //SFDataPacket Packet23 = new SFDataPacket(new string[] { "E", "S", "33598472", "0", "283", "2", "3.9000001", "246", "68.67158508", "246,69#246,70#246,71#246,72#246,73#246,74#246,75#246,76#246,77#246,78#246,79#246,80#246,81#246,82#246,83#246,84#246,85", "TestShip", "WW2", "87320", "88800", "0", "150000", "300", "426", "0", "0", "0", "15", "1", "7,0,0,0", "", "0", "fl=0#ns=0#hr=10.0#bhp=88800" });
            //byte[] InitDisplay23 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet23.create_message(), false) + "\0");
            //Session.Sock.NoDelay = true;
            //Session.Sock.Send(InitDisplay23);

            SFDataPacket Packet2 = new SFDataPacket(new string[] { "E", "S", Session.UserID + "", "0", Session.Row["design"] + "", "2", "3.36995888", "310", "-155", "", Session.Row["username"] + "", "WW", "200000", "200000", "100", "100", "800", "99111", "100", "100", "100", "20", "10000", "0,10,1,1", "", "0", "fl=0#ns=0#hr=1000#csr=2000#bhp=" + Session.Row["mhp"] + "", "0", "225011", "991111", "1,1800000000#100,50000000000#51,22000000000", "75,5555#1,1222", "18", "0", "800", "800", "800", "", "0", "0" });
            byte[] InitDisplay2 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet2.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay2);

            SFDataPacket Packet17 = new SFDataPacket(new string[] { "D", "M", Session.Row["hp"] + "", Session.Row["mhp"] + "", Session.Row["vp"] + "", Session.Row["mvp"] + "", Session.Row["ep"] + "", Session.Row["mep"] + "", "1", "75", "1.70008326", "50", "18", "1,1800000000#100,50000000000#51,22000000000", "75,10000#1,1222", "5", "5", "1", "1", "1", "fl=0#ns=0#hr=10#csr=20" });
            byte[] InitDisplay17 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet17.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay17);

            //D|M|1675|2000|4000|4000|3|2250|1|75|1.70008326|50|18|1,180#120,500#51,220|75,10|0|0|1|1|1|fl=0#ns=0#hr=10#csr=20
            SFDataPacket Packet3 = new SFDataPacket(new string[] { "D", "V", "10,10,10,10,15,15,15,10,10,10,10,10,10,10,10", "5,5,5,5,5,5,5,5,5,5,5,5,5,5,5" });
            byte[] InitDisplay3 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet3.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay3);

            SFDataPacket Packet4 = new SFDataPacket(new string[] { "A", "I", "15,12311,0,0#10,12311,0,0" });
            byte[] InitDisplay4 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet4.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay4);

            SFDataPacket Packet5 = new SFDataPacket(new string[] { "D", "B", "B", "51#200000000" });
            byte[] InitDisplay5 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet5.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay5);

            SFDataPacket Packet6 = new SFDataPacket(new string[] { "D", "T", "0", "#map_pvp" });
            byte[] InitDisplay6 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet6.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay6);

            SFDataPacket Packet7 = new SFDataPacket(new string[] { "INF", "S", "1", "0" });
            byte[] InitDisplay7 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet7.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay7);

            SFDataPacket Packet8 = new SFDataPacket(new string[] { "W", "E", "O", "22", "0" });
            byte[] InitDisplay8 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet8.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay8);

            SFDataPacket Packet9 = new SFDataPacket(new string[] { "W", "E", "U", "22", "0", "771366969060" });
            byte[] InitDisplay9 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet9.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay9);

            SFDataPacket Packet10 = new SFDataPacket(new string[] { "D", "I", "4", "49", "" });
            byte[] InitDisplay10 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet10.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay10);

            //E|I|1000070091|1|461|-103|0
            SFDataPacket Packet11 = new SFDataPacket(new string[] { "IN", "I", "" });
            byte[] InitDisplay11 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet11.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay11);

            SFDataPacket Packet12 = new SFDataPacket(new string[] { "AC", "L", "1", "2,3,4,5,7,8,9,11,12,13,14,15,16", "2,3,4,5,7,8,9,11,12,13,14,15,16", "6000,6000,81,51,20,50,100,30,3500,100,100,6000,120", "99,99,99,99,99,99,99,99,99,99,99,99,99" });
            byte[] InitDisplay12 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet12.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay12);

            SFDataPacket Packet13 = new SFDataPacket(new string[] { "AC", "L", "2", "6", "6", "35", "99" });
            byte[] InitDisplay13 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet13.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay13);

            SFDataPacket Packet14 = new SFDataPacket(new string[] { "AC", "L", "", "3", "", "", "", "" });
            byte[] InitDisplay14 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet14.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay14);

            SFDataPacket Packet15 = new SFDataPacket(new string[] { "D", "S", "2" });
            byte[] InitDisplay15 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet15.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay15);

            DataTable Table2 = Form1.Client.ReadDataTable("SELECT * FROM npc");
            foreach (DataRow DRow in Table2.Rows)
            {
                SFDataPacket Packet24 = new SFDataPacket(new string[] { "E", "S", DRow["id"] + "", "0", DRow["design"] + "", "1", "0.71065241", DRow["x"] + "", DRow["y"] + "", "", DRow["name"] + "", "NPC", DRow["hp"] + "", DRow["mhp"] + "", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0,0,0,0", "", "0", "fl=0#ns=0#hr=12.0#bhp=" + DRow["mhp"] });
                byte[] InitDisplay24 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet24.create_message(), false) + "\0");
                Session.Sock.NoDelay = true;
                Session.Sock.Send(InitDisplay24);
            }

            //E|S|1000434082|0|17|1|0.71065241|322|-165||Rackham||1201|1201|0|0|0|0|0|1|0|0|0|0,0,0,0||0|fl=0#ns=0#hr=12.0#bhp=1201&&
            DataTable Table = Form1.Client.ReadDataTable("SELECT * FROM collectables");
            foreach (DataRow DRow in Table.Rows)
            {
                SFDataPacket Packet22 = new SFDataPacket(new string[] { "E", "I", DRow["id"] + "", DRow["cid"] + "", DRow["x"] + "", DRow["y"] + "", "0" });
                byte[] InitDisplay22 = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet22.create_message(), false) + "\0");
                Session.Sock.NoDelay = true;
                Session.Sock.Send(InitDisplay22);
            }
        }
    }
}
