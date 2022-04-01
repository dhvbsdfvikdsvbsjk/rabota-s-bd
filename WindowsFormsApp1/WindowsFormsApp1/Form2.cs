using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    
    public partial class Form2 : Form
    {// строка для взаимодейтсвия с фото
        private Bitmap bmp;
        // строка для подключения БД с sql
        public static string str = @"Data Source=wsr-srv\sqlexpress;Initial Catalog=01;Integrated Security=True";
        private SqlConnection con = new SqlConnection(str);
        public Form2()
        {
            InitializeComponent();
            string query = "USE[01] SELECT * FROM [dbo].[Лист1$]";  
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_01DataSet._Лист1_". При необходимости она может быть перемещена или удалена.
            con.Open();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "";
if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                bmp = new Bitmap(image);
                pictureBox1.Image = bmp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { // переход между формами
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void form2_close(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Данные из текстбокса будут перенесены в БД  
            string id = textBox1.Text;
            string name = textBox2.Text;
            string midname = textBox3.Text;
            string pas = textBox4.Text;
            string pasn = textBox5.Text;
            string addr = textBox6.Text;
            string addrlif = textBox7.Text;
            string com = textBox8.Text;
            string job = textBox9.Text;
            string phone = textBox10.Text;
            string photo = pictureBox1.Text;
            string email = textBox11.Text;
            string des = textBox13.Text;
            // проверка ЕМейла на правильность наличие @ и .
            string pata = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Match isMatch = Regex.Match(email, pata, RegexOptions.IgnoreCase);

            if (textBox11.Text == isMatch.ToString())
                    {
                // проверяет соответвие текстбоксов и столбцов БД
                string Query2 = $"INSERT INTO [dbo].[Лист1$]([id],[name],[middlename],[passport serial],[passport number],[postcode],[address],[address life],[company],[jobname],[phone],[email],[photo],[description]) " +
        $"values (" + id + ",'" + name + "','" + midname + "'," + pas + "," + pasn + ",452,'" + addr + "','" + addrlif + "','" + com + "','" + job + "'," + phone + ",'" + email + "','" + photo + "','" + des + "')";
                SqlCommand Command2 = new SqlCommand(Query2, con);
                Command2.ExecuteNonQuery();
            }
                else
                {
                    MessageBox.Show("Неверный адрес");
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }
    }
}
