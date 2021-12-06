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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            //экземпляр класса, находящийся в  Program.cs
            Connection conn = new Connection();
            //Инициализация соединения с  бд, с экземпляра conn
            MySqlConnection connect = new MySqlConnection(conn.stringconnection);
            //Переменная содержит запрос SQL на вывод информации из таблицы t_stud
            string sql = $"SELECT id, fio, theme_kurs FROM t_stud";
            try
            {
                connect.Open(); //открытие соединения
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);
                DataSet dataset = new DataSet(); //создание виртуальная таблица
                IDataAdapter.Fill(dataset);//заполнение виртуальной таблицы
                dataGridView1.DataSource = dataset.Tables[0];
            }
            finally
            {
                //закрытие соединение
                connect.Close();
            }
        }
        string id_rows = "0";
        //Метод срабатывает по нажатию кнопки мыши на DataGrid
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Условие, которое срабатывает при нажатии какого либо поля при нажатии левой кнопки мыши
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                //определяется строка, которую мы нажали
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                //выбранная строка подсвечивается программой
                dataGridView1.CurrentRow.Selected = true;
                string index_rows;
                //В переменную попадает индекс ячейки, который мы выбрали нажатием
                index_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                //Переменная, которую мы объявили глобально присваивается значение второй
                id_rows = dataGridView1.Rows[Convert.ToInt32(index_rows)].Cells[1].Value.ToString();
                MessageBox.Show(id_rows);
            }
        }
    }
}

