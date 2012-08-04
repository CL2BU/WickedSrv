using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace WickedSrv___EOS_Edition.Commons.MySQL
{
    class SqlHelpers
    {
        public static string CreateConnectionString(String Host, UInt32 Port, string User, string Password, string Database)
        {
            MySqlConnectionStringBuilder MySqlConnect = new MySqlConnectionStringBuilder();

            // Server
            MySqlConnect.Server = Host;
            MySqlConnect.Port = Port;
            MySqlConnect.UserID = User;
            MySqlConnect.Password = Password;

            // Database
            MySqlConnect.Database = Database;
            MySqlConnect.MinimumPoolSize = 0;
            MySqlConnect.MaximumPoolSize = 30;

            return MySqlConnect.ToString();
        }
    }
}
