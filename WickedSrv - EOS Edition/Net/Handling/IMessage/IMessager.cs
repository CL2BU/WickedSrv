using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WickedSrv___EOS_Edition.Net.Handling.IMessage
{
    interface IMessager
    {
        void Handle(Session Session, String data);
    }
}
