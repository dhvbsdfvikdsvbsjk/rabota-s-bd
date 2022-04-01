using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z6
{
    public partial class Form01 : Form
    {
        public Form01()
        {
            // добавление значений в комбобокс
            InitializeComponent();
            comboBox1.Items.Add("столкновение");
            comboBox1.Items.Add("опрокидывание");
            comboBox1.Items.Add("наезд на стоящее транспортное средство");
            comboBox1.Items.Add("наезд на препятствие");
            comboBox1.Items.Add("наезд на пешехода");
            comboBox1.Items.Add("наезд на велосипедиста");
            comboBox1.Items.Add("наезд на животное");
            comboBox1.Items.Add("иные виды ДТП (происшествия, не относящиеся к указанным выше видам)");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // условие комбобокс записывает выбраные данные в класс
            switch(comboBox1.Text)
            {
                case "столкновение":
                    Sa.a = comboBox1.Text;
                    break;
                case "опрокидывание":
                    Sa.a = comboBox1.Text;
                    break;
                case "наезд на стоящее транспортное":
                    Sa.a = comboBox1.Text;
                    break;
                case "наезд на препятствие":
                    Sa.a = comboBox1.Text;
                    break;
                case "наезд на пешехода":
                    Sa.a = comboBox1.Text;
                    break;
                case "наезд на велосипедиста":
                    Sa.a = comboBox1.Text;
                    break;
                case "наезд на животное":
                    Sa.a = comboBox1.Text;
                    break;
                case "иные виды ДТП (происшествия, не относящиеся к указанным выше видам)":
                    Sa.a = comboBox1.Text;
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // переход между формами
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
