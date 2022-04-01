using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z6
{
    public partial class Form2 : Form
    {
        int pbw, pbh, pbx, pby;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double mh, mw; // коэффициенты масштабирования
            pictureBox1.Visible = false;
            pictureBox1.Left = pbx;
            //загружаем изображение в pictureBox1
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = new Bitmap(apath + "\\" +
            listBox1.SelectedItem.ToString());
            //масштабируем, если нужно
            if ((pictureBox1.Image.Width > pbw) || (pictureBox1.Image.Height >
            pbh))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                mh = (double)pbh / (double)pictureBox1.Image.Height;
                mw = (double)pbw / (double)pictureBox1.Image.Width;
                if (mh < mw)
                {
                    //масштабируем по ширине
                    pictureBox1.Width = Convert.ToInt16(pictureBox1.Image.Width *
                    mh);
                    pictureBox1.Height = pbh;
                }
                else
                {
                    //масштабираем по высоте
                    pictureBox1.Width = pbw;
                    pictureBox1.Height = Convert.ToInt16(pictureBox1.Image.Height
                    * mw);
                }
            }
            //разместить картинку в центре области отображения иллюстраций
            pictureBox1.Left = pbx + (pbw - pictureBox1.Width) / 2;
            pictureBox1.Top = pby + (pbh - pictureBox1.Height) / 2;
            pictureBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog - окно Обзор папок
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "выберите папку,\n" + "в которой находятся иллюстрации";
fb.ShowNewFolderButton = false;
            //отображаем диалоговое окно
            if (fb.ShowDialog() == DialogResult.OK)
            {
                //пользователь выбрал каталог и щелкнул по кнопке ОК
                apath = fb.SelectedPath;
                label1.Text = apath;
                if (!FillListBox(fb.SelectedPath))
                    //в каталоге нет файлов иллюстраций
                    pictureBox1.Image = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // сохраняет имя фотографии в класс и перемещяется в формах
            Sa.Photo = listBox1.Text;
            Form1 f = new Form1();
            f.Show();
            this.Hide();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MakeScreenshot();
        }
        public static void MakeScreenshot()
        {
            // получаем размеры окна рабочего стола
            Rectangle bounds = Screen.GetBounds(Point.Empty);

            // создаем пустое изображения размером с экран устройства
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                // создаем объект на котором можно рисовать
                using (var g = Graphics.FromImage(bitmap))
                {
                    // перерисовываем экран на наш графический объект
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                // сохраняем в файл с форматом JPG
                bitmap.Save("screenshot_03.jpg", ImageFormat.Jpeg);
            }
        }
        string apath;
        public Form2()
        {
            InitializeComponent();
            pbh = pictureBox1.Height;
            pbw = pictureBox1.Width;
            pbx = pictureBox1.Location.X;
            pby = pictureBox1.Location.Y;
            //элементы ListBox1 сортируются в алфавитном порядке
            listBox1.Sorted = true;
            DirectoryInfo di; //католог
                              //получить имя каталога "Мои рисунки"
            di = new
            DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            apath = di.FullName;
            label1.Text = apath;
            //сформировать список иллюстраций
            FillListBox(apath);
        }
        private Boolean FillListBox(string path)
        {
            //информация о каталоге
            DirectoryInfo di = new DirectoryInfo(path);
            //информация о файлах
            FileInfo[] fi = di.GetFiles("*.png");
            //очистить список ListBox
            listBox1.Items.Clear();
            // добавляеим в ListBox1 имена jpg-файлов, содержащихся в каталоге
            foreach (FileInfo fc in fi)
            {
                listBox1.Items.Add(fc.Name);
            }
            label1.Text = apath;
            if (fi.Length == 0) return false;
            else
            {
                //выбираем первый файл из полученного списка
                listBox1.SelectedIndex = 0;
                return true;
            }
        }
    }
}
