using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // проверка текстбоксов если они пустые вывод сообщения о пустых полях
            if (textBox1.Text.Length > 0 || textBox2.Text.Length > 0 || textBox3.Text.Length > 0 || textBox4.Text.Length > 0 || textBox5.Text.Length > 0
                || textBox6.Text.Length > 0 || textBox10.Text.Length > 0 || textBox14.Text.Length > 0
                || textBox15.Text.Length > 0 || textBox16.Text.Length > 0 || textBox17.Text.Length > 0)
            {
                MessageBox.Show("j-j");
            }
            else
            {
                MessageBox.Show("Пустое поле");
            }
        }
    }
}
