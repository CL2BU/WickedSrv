using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WickedSrv___EOS_Edition.Net.Handling.IMessage;
using WickedSrv___EOS_Edition.Commons.Encrypting;
using WickedSrv___EOS_Edition.Net.Handling.Outgoing;

namespace WickedSrv___EOS_Edition.Net.Handling
{
    class PacketHandler
    {
        public static Dictionary<int, IMessager> Messages = new Dictionary<int, IMessager>();
        public static void GenerateAll()
        {
            //Global
            Messages.Add(Convert.ToInt32("B"), new MapLoadMessageEvent());
            Messages.Add(Convert.ToInt32("LOGIN"), new UserLoginMessageEvent());
            Messages.Add(Convert.ToInt32("L"), new LogoutMessageEvent());

            //Attack
            Messages.Add(Convert.ToInt32('A'), new AttackMessageEvent());

            //Pathfinding
            Messages.Add(Convert.ToInt32('M'), new PathfindMessageEvent());
        }

        public static void HandlePacket(Session Session, String data)
        {
            if (data.Length > 0)
            {
                string[] splitted = data.Split('|');
                if (Messages.ContainsKey(Convert.ToInt32(splitted[0])))
                {
                    Messages[Convert.ToInt32(splitted[0][0])].Handle(Session, data);
                    Form1.getManager().Print("Handled Packet: " + Convert.ToInt32(splitted[0]));
                }
                else
                {
                    Form1.getManager().Print("Unhandled Packet: " + Convert.ToInt32(splitted[0]));
                }
            }
        }
    }
}