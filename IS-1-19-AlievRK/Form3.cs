using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_1_19_AlievRK
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        class Connection
        {
         public string stringconnection = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";

            public void ConnectInfo()
            {
                MessageBox.Show(stringconnection);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            MySqlConnection conn = new MySqlConnection(con.stringconnection);
            bool result = true;
            try
            {
                conn.Open();
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (result == true)
                {
                    MessageBox.Show("Подключение работает отлично!");
                }
                else
                {
                    MessageBox.Show("Подключение не работает, нужно устронить неполадки!");
                }
            }
        }
    }
}
