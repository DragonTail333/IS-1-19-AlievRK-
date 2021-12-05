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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            MySqlConnection connect = new MySqlConnection(conn.stringconnection);
            string dateitimeStud = textBox2.Text; //правильно записывать нужно так: yyyy-MM-dd hh:mm:ss иначе ничего не получится.
            string fioStud = textBox1.Text;
            string sql = $"INSERT INTO t_PraktStud (fioStud, datetimeStud)  VALUES ('{fioStud}','{dateitimeStud}');";
            int counter = 0;
            try
            {
                connect.Open();
                MySqlCommand command1 = new MySqlCommand(sql, connect);
                counter = command1.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Данные не добавлены, что-то пошло не так!");
            }
            finally
            {
                connect.Close();

                if (counter != 0)
                {
                    MessageBox.Show("Данные добавлены!");
                }
            }
        }
    }
}
