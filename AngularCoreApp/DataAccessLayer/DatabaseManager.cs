using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    public interface IDatabaseManager
    {
        SqlConnection GetConnection();
    }
    public class DatabaseManager: IDatabaseManager
    {
        private string strConnection = @"Data Source=.;Initial Catalog=FeedBack;Integrated Security=true;";
        private SqlConnection _sqlConnection;
        public DatabaseManager()
        {
            _sqlConnection = new SqlConnection(strConnection);
        }
        public SqlConnection GetConnection()
        {
            return this._sqlConnection;
        }
    }
}
