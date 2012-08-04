using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WickedSrv___EOS_Edition.Commons.MySQL
{
    class SqlData
    {
        private DataRow Row;

        public SqlData(DataRow Row)
        {
            this.Row = Row;
        }
        public string PopString(String Coloumn)
        {
            return Row[Coloumn].ToString();
        }
        public int PopInt32(String Coloumn)
        {
            return (int)Row[Coloumn];
        }
    }
}
