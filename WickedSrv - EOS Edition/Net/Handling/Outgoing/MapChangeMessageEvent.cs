using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WickedSrv___EOS_Edition.Commons.Packet;
using WickedSrv___EOS_Edition.Commons.Encrypting;
using WickedSrv___EOS_Edition.Net.Handling.IMessage;

namespace WickedSrv___EOS_Edition.Net.Handling.Outgoing
{
    class MapChangeMessageEvent : IMessager
    {
        public void Handle(Session Session, String data)
        {
            SFDataPacket Packet = new SFDataPacket(new string[] { "D", "S", "1", "2", "#warmap:mapchange", "1" });
            byte[] InitDisplay = Encoding.Default.GetBytes(Encoders.DecryptMsg(Packet.create_message(), false) + "\0");
            Session.Sock.NoDelay = true;
            Session.Sock.Send(InitDisplay);
            //D|S|1|2|#warmap:mapchange|1
        }
    }
}
