using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void лист1_BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.лист1_BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._01DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_01DataSet._Лист1_". При необходимости она может быть перемещена или удалена.
            this.лист1_TableAdapter.Fill(this._01DataSet._Лист1_);
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Добавить новую строку, добавляет в самый конец БД
            лист1_BindingSource.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // сохраняет значение текстбоксов и добавляет их в БД
            лист1_BindingSource.EndEdit();
            лист1_TableAdapter.Update(_01DataSet);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // удаляет строку БД
            лист1_BindingSource.RemoveCurrent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Случайно определяет какое число будет соответсвовать значениям для определения цвета
            Random rnd = new Random();
            Random r = new Random();
            int a, b, c, d;
            for (int i = 0; i < 30; i++)
            {
                a = rnd.Next(4, 200);
                b = rnd.Next(4, 200);
                c = rnd.Next(4, 200);
                d = rnd.Next(4, 200);
                if (idTextBox.Text == a.ToString())
                {
                    label1.Text = "активен";
                    this.BackColor = Color.Green;
                }                    
                else if (idTextBox.Text == b.ToString())
                {
                    label1.Text = "приостановлен";
                    this.BackColor = Color.Red;
                }
                   
                else if (idTextBox.Text == c.ToString())
                {
                    label1.Text = "утратил силу";
                    this.BackColor = Color.Red;
                }                   
                else if (idTextBox.Text == d.ToString())
                {
                    label1.Text = "изъят";
                    this.BackColor = Color.Gray;
                }
            }                       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // перервод значений Текстбокса в классы
            Aa.a0 = idTextBox.Text;
            Aa.a1 = nameTextBox.Text;
            Aa.a2 = middlenameTextBox.Text;
            Aa.a3 = passport_serialTextBox.Text;
            Aa.a4 = passport_numberTextBox.Text;
            Aa.a5 = postcodeTextBox.Text;
            Aa.a6 = addressTextBox.Text;
            Aa.a7 = address_lifeTextBox.Text;
            Aa.a8 = companyTextBox.Text;
            Aa.a9 = jobnameTextBox.Text;
            Aa.a10 = phoneTextBox.Text;
            Aa.a11 = emailTextBox.Text;
            Aa.a12 = photoTextBox.Text;
            Aa.a13 = descriptionTextBox.Text;
            Aa.ppch = label1.Text;
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
    }
}
