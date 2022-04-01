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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void asdBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.asdBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._02DataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_02DataSet.asd". При необходимости она может быть перемещена или удалена.
            this.asdTableAdapter.Fill(this._02DataSet.asd);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // данные из текстбоксов данной формы будут записанны в переменные класса для того чтобы выгрузить их в бд другой формы
            idTextBox.Text = Aa.a0;
            nameTextBox.Text = Aa.a1;
            middlenameTextBox.Text = Aa.a2;
            passport_serialTextBox.Text = Aa.a3;
            passport_numberTextBox.Text = Aa.a4;
            postcodeTextBox.Text = Aa.a5;
            addressTextBox.Text = Aa.a6;
            address_lifeTextBox.Text = Aa.a7;
            companyTextBox.Text = Aa.a8;
            jobnameTextBox.Text = Aa.a9;
            phoneTextBox.Text = Aa.a10;
            emailTextBox.Text = Aa.a11;
            phoneTextBox.Text = Aa.a12;
            descriptionTextBox.Text = Aa.a13;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // удаляет строку в бд
            asdBindingSource.RemoveCurrent();
        }
    }
}
