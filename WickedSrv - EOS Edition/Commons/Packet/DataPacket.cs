using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WickedSrv___EOS_Edition.Commons.Packet
{
    public class SFDataPacket
    {
        private List<string[]> _data;
        private static string SPLITATTRIBUTES = "|";
        private static string SPLITOBJECT = "&";

        public SFDataPacket()
        {
            this._data = new List<string[]>();
        }

        public SFDataPacket(string[] sobject)
        {
            this._data = new List<string[]>();
            this._data.Add(sobject);
        }

        public void add(string[] string_array)
        {
            this._data.Add(string_array);
        }

        public string create_message()
        {
            string str = "";
            foreach (string[] strArray in this._data)
            {
                string str2 = "";
                foreach (string str3 in strArray)
                {
                    str2 = str2 + str3 + SPLITATTRIBUTES;
                }
                str2 = str2.Substring(0, str2.Length - 1);
                str = str + str2 + SPLITOBJECT;
            }
            return str.Substring(0, str.Length - 1);
        }

        public static SFDataPacket create_packet(string message)
        {
            SFDataPacket packet = new SFDataPacket();
            List<string[]> list = new List<string[]>();
            string[] strArray = message.Split(new string[] { SPLITOBJECT }, StringSplitOptions.None);
            foreach (string str in strArray)
            {
                string[] item = str.Split(new string[] { SPLITATTRIBUTES }, StringSplitOptions.None);
                list.Add(item);
            }
            packet._data = list;
            return packet;
        }

        public List<string[]> data
        {
            get
            {
                return this._data;
            }
            set
            {
                value = this._data;
            }
        }
    }
}
