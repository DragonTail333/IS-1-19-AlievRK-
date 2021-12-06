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
         //строка подключения
         public string stringconnection = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
            //Метод, который предназначен для ввод информации о строке подключения
            public void ConnectInfo()
            {
                MessageBox.Show(stringconnection);
            }
        }
        //Кнопка, для проверки соединения
        private void button1_Click(object sender, EventArgs e)
        {
            //экземпляр класса
            Connection con = new Connection();
            //строка подключения
            MySqlConnection conn = new MySqlConnection(con.stringconnection);
            bool result = true;
            try
            {
                conn.Open(); //Метод соединения с бд.
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (result == true)
                {
                    //Если соединение провелось успешно, то высветит вот это сообщение
                    MessageBox.Show("Подключение работает отлично!");
                }
                else
                {
                    //Если соединение провелось успешно, то высветит вот это сообщение
                    MessageBox.Show("Подключение не работает, нужно устронить неполадки!");
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
