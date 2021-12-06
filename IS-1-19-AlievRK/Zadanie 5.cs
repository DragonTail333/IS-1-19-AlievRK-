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

            ConnectDB conn = new ConnectDB(); //Экземпляр класса из библиотеки из другого проекта 
            MySqlConnection connect = new MySqlConnection(conn.stringconnectionDB); //создаём соединение
            string dateitimeStud = textBox2.Text; //правильно записывать нужно так: yyyy-MM-dd hh:mm:ss иначе ничего не получится.
            string fioStud = textBox1.Text; // зздесь записывать ФИО студента
            string sql = $"INSERT INTO t_PraktStud (fioStud, datetimeStud)  VALUES ('{fioStud}','{dateitimeStud}');";
            int counter = 0;
            try
            {
                //попытка подключения
                connect.Open();
                //экземпляр MySqlComman, который позволит выполнять команду по изменению БД
                MySqlCommand command1 = new MySqlCommand(sql, connect);
                //Метод, который позволяет выполнять указанную выше команду 
                counter = command1.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Данные не добавлены, что-то пошло не так!");
            }
            finally
            {
                connect.Close(); //соединение закрывается

                if (counter != 0) // Если counter больше 0, то значит мы добавили в базу данных.
                {
                    MessageBox.Show("Данные добавлены!");
                }
            }
        }
    }
}
