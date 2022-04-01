using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        private readonly object b = new object();
        private decimal ba;
        // Работа с файлами пользователей
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
        // Возвращает время бездействия пользователя.
        public static uint GetIdleTime()
        {
            LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
            LastUserAction.cbSize = (uint)Marshal.SizeOf(LastUserAction);
            GetLastInputInfo(ref LastUserAction);
            return (uint)Environment.TickCount - LastUserAction.dwTime;
        }

        public Form1()
        {
            InitializeComponent();
            
        }
        private int count = 3;
        private void button1_Click(object sender, EventArgs e)
        { 
            // добавление пароля в регистр для дальнейшей проверки пароли
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey localMachineKey = Registry.LocalMachine;
            RegistryKey helloKey = currentUserKey.OpenSubKey("Bay");
            string ye;
            string ue;
           ye = helloKey.GetValue("login").ToString();
           ue = helloKey.GetValue("password").ToString();
            helloKey.Close();     
            // проверка пароля через регистр
                if (textBox1.Text == ye & textBox2.Text==ue)
                {
                // переход на другую форму
                Form3 f = new Form3();
                f.Show();
                this.Hide();
                }
            else
            {                 // вывод сколько попыток осталось в случае неверного пароля                     
                    MessageBox.Show($"Пароль неверный осталось {count} попытки");
                if (count-- == 0)
                {
                    lock(b)
                    { // блокировка всех элементов 
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        button1.Enabled = false;
                        timer2.Start();
                    }
                                     
                }
                else if (count == -1)
                {
                    Application.Exit();
                }
            }
        }
        Timer timer1 = new Timer();
        int o = 0;
        int s = 60;
        private void Form1_Load(object sender, EventArgs e)
        { // настройки таймера
            timer1.Tick += new EventHandler(timer2_Tick);
            timer1.Interval = 10000;
            timer3.Interval = 1000;
            timer3.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            // настройки таймера если все 3 попытки не верны
            button1.Enabled = true;
            count = 3;
            s = s - 2 + 1;
            if(s <= 0)
            {
                s = 59;
            }
            if(s == 0)
            { // блокировка элементов
                timer2.Stop();
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
            } // возвращает элементы к нулю
            label4.Text = Convert.ToString(s);
            textBox1.Text = ""; textBox2.Text = "";
            
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (GetIdleTime() >= 10000)// Проверка времени бездейтсвия.
                this.Close();
        }
    }
}
