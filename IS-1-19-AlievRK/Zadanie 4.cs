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
using ConnectDB;

namespace IS_1_19_AlievRK
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        
        private void Form5_Load(object sender, EventArgs e)
        {
            //Экземпляр класса, добавленного из другого проекта того же репозитория
            ConnectDB conn = new ConnectDB();
            MySqlConnection connect = new MySqlConnection(conn.stringconnectionDB);
            //Переменная содержит запрос на вывод столбцов из таблицы t_datetime
            string sql = $"SELECT idStud, fioStud, drStud FROM t_datetime";
            try
            {
                connect.Open(); //Открываем соединение
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);
                //Создаём виртуальную таблицу
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                //предаём DataGrid вид заполненной нами виртуальной таблицы
                dataGridView1.DataSource = dataset.Tables[0];
            }
            finally
            {
                //Закрываем соеднинение
                connect.Close();
            }
        }

        string id_rows = "0";
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
                string index_rows5;
                index_rows5 = dataGridView1.SelectedCells[0].RowIndex.ToString();
                id_rows = dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString();
                DateTime x = DateTime.Today; // Получает настоящую дату на данный момент
                DateTime y = Convert.ToDateTime(dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString());
                string resultDays = (x - y).ToString();  // здесь хранится значение, которое соответствует прошедшим дням
                MessageBox.Show(resultDays.Substring(0, resultDays.Length - 9) + " дней прошло со дня рождения!"); 
            }
        }
    }
}
