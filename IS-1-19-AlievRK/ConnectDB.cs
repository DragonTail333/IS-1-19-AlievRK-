using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_1_19_AlievRK
{
    class ConnectDB
    {
        public string stringconnectionDB = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";

        public void ConnectInfo()
        {
            MessageBox.Show(stringconnectionDB);
        }
    }
}
