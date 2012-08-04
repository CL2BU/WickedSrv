using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;

namespace WickedSrv___EOS_Edition.Commons.MySQL
{
    public class SqlClient
    {
        private string connectionString;
        private MySqlConnection mySqlConnection;
        private MySqlCommand mySqlCommand;

        public void CreateClient()
        {
            // Generate a connection string
            this.connectionString = SqlHelpers.CreateConnectionString("localhost", Convert.ToUInt32("3306"), "root", "hobbitex99", "seafight");

            // Connect and create a command for running querys
            this.mySqlConnection = new MySqlConnection(this.connectionString);
            this.mySqlConnection.Open();

            // Create command
            this.mySqlCommand = mySqlConnection.CreateCommand();
        }
        public SqlClient GetClient()
        {
            SqlClient MySql = new SqlClient();
            
            MySql.CreateClient();

            return MySql;
        }
        public void AddPreparedValue(String sParam, object val)
        {
            if (mySqlCommand.Parameters.Contains(sParam))
            {
                mySqlCommand.Parameters.Remove(sParam);
            }

            mySqlCommand.Parameters.AddWithValue(sParam, val);
        }
        public void ExecuteQuery(String sQuery)
        {
            mySqlCommand.CommandText = sQuery;
            mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = null;
        }

        public DataTable ReadDataTable(String sQuery)
        {
            DataTable pDataTable = new DataTable();

            mySqlCommand.CommandText = sQuery;

            using (MySqlDataAdapter pAdapter = new MySqlDataAdapter(mySqlCommand))
            {
                pAdapter.Fill(pDataTable);
            }
            mySqlCommand.CommandText = null;

            return pDataTable;
        }
        public DataRow ReadDataRow(String sQuery)
        {
            DataTable pDataTable = ReadDataTable(sQuery);

            if (pDataTable != null && pDataTable.Rows.Count > 0)
            {
                return pDataTable.Rows[0];
            }

            return null;
        }
        public bool ReadBoolean(String sQuery)
        {
            bool found = false;

            mySqlCommand.CommandText = sQuery;
            try
            {
                using (var reader = mySqlCommand.ExecuteReader())
                {
                    found = reader.HasRows;
                }
            }
            catch { }

            return found;
        }
        public string ReadString(String sQuery)
        {
            mySqlCommand.CommandText = sQuery;
            string result = mySqlCommand.ExecuteScalar().ToString();
            mySqlCommand.CommandText = null;

            return result;
        }
    }
}
