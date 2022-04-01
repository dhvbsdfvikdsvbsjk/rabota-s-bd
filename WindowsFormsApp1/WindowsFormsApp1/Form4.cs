using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        // подключение бд к форме
        public static string str = @"Data Source=wsr-srv\sqlexpress;Initial Catalog=01;Integrated Security=True";
        private SqlConnection con = new SqlConnection(str);
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con.Open();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_01DataSet._Лист1_". При необходимости она может быть перемещена или удалена.
            this.лист1_TableAdapter.Fill(this._01DataSet._Лист1_);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // переход между строками
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // удаляет строчку из бд
            int aaa =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string ae = aaa.ToString();
            string Query2 = $"delete from [dbo].[Лист1$] where id ={ Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())}";        
SqlCommand Command2 = new SqlCommand(Query2, con);
            Command2.ExecuteNonQuery();
        }

        private void form4_close(object sender, FormClosingEventArgs e)
        {
            // закрывает бд при закрытии формы 
            con.Close();
        }
    }
}
