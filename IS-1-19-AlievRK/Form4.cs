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
            Connection conn = new Connection();
            MySqlConnection connect = new MySqlConnection(conn.stringconnection);
            string sql = $"SELECT id, fio, theme_kurs FROM t_stud";
            try
            {
                connect.Open();
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            finally
            {
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
                string index_rows;
                index_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                id_rows = dataGridView1.Rows[Convert.ToInt32(index_rows)].Cells[1].Value.ToString();
                MessageBox.Show(id_rows);
            }
        }
    }
}

