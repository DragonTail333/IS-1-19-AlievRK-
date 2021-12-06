using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectDB
{
    public static class ConnToDB
    {
        public static MySqlConnection ConnectDB(string connStr)
        {
          connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
            MySqlConnection connection = new MySqlConnection(connStr);
            return connection; 
        }
        
    }
}
