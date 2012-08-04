using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WickedSrv___EOS_Edition.Net.Handling.IMessage;
using WickedSrv___EOS_Edition.Commons.Encrypting;
using WickedSrv___EOS_Edition.Commons.Packet;
using System.Data;
using System.Threading;

namespace WickedSrv___EOS_Edition.Net.Handling.Outgoing
{
    class AttackMessageEvent : IMessager
    {
        public void Handle(Session Session, String data)
        {
            string[] SplittedData = data.Split('|');
            if (SplittedData[1] == "1")
            {
                if (SplittedData[2] == "1")
                {
                    SFDataPacket Packet = new SFDataPacket(new string[] { "D", "H", "1", "1", SplittedData[3], "0", "0", "", "", "0", Session.UserID + "", "1", "500", "0", "0", "150", Session.Row["username"] + "" });
                    byte[] InitDisplay = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet.create_message(), false) + "\0");
                    Session.Sock.NoDelay = true;
                    Session.Sock.Send(InitDisplay);
                }
                else
                {
                    try
                    {
                        int baseHit = 75;
                        int cannonsOn = int.Parse(Session.Row["canons"] + "");
                        int maxHit = (baseHit * cannonsOn);

                        DataRow Row2 = Form1.Client.ReadDataRow("SELECT * FROM npc WHERE id = '" + SplittedData[3] + "'");
                        int NPCHp = int.Parse(Row2["hp"] + "");
                        double maxHits = (NPCHp / maxHit);

                        for (int hit = 0; hit < 555; hit++)
                        {
                            DataRow Row3 = Form1.Client.ReadDataRow("SELECT * FROM npc WHERE id = '" + SplittedData[3] + "'");
                            int NPCHp2 = int.Parse(Row3["hp"] + "");
                            int newNPCHp2 = (NPCHp2 - maxHit);
                            if (newNPCHp2 <= 0)
                            {
                                SFDataPacket Packet = new SFDataPacket(new string[] { "O", "S", SplittedData[3], "1", Session.UserID + "", "#warmap:killpirategold", Row3["rewards"] + "" });
                                byte[] InitDisplay = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet.create_message(), false) + "\0");
                                Session.Sock.NoDelay = true;
                                Session.Sock.Send(InitDisplay);
                                Form1.getManager().Print(Packet.create_message());
                                //O|S|1000433879|1|14508410|#warmap:killpirategold|1595!4
                                break;
                            }
                            else
                            {
                                SFDataPacket Packet = new SFDataPacket(new string[] { "D", "H", "0", "1", SplittedData[3], newNPCHp2 + "", "0", "0.64999998", "0", "0", Session.UserID + "", "1", maxHit + "", "0", "0", "150", Session.Row["username"] + "" });
                                byte[] InitDisplay = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet.create_message(), false) + "\0");
                                Session.Sock.NoDelay = true;
                                Session.Sock.Send(InitDisplay);
                                Form1.Client.ExecuteQuery("UPDATE npc SET hp = '" + newNPCHp2 + "' WHERE id = '" + SplittedData[3] + "'");
                                Form1.getManager().Print(Packet.create_message());
                                Thread.Sleep(3000);
                            }
                        }
                    }
                    catch (Exception ex) { Form1.getManager().Print(ex.ToString()); }
                }
            }
            //A|1|0|1000401027|1
            //D|H|0|1|1000483882|0|0|0.64999998|0|0|14508410|1|446|0|0|150|
            //D|H|1|1|1000478265|338|0|||0|14508410|1|50|0|0|150|USERNAME
        }
    }
}
