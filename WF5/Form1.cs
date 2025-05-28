using System;
using System.Drawing;
using System.Windows.Forms;

namespace WF5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            // Получаем количество квадратов из TextBox
            if (!int.TryParse(textBoxCount.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Введите положительное число квадратов!");
                return;
            }

            // Очищаем PictureBox
            pictureBox1.Image = null;

            // Создаем Bitmap для рисования
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); // Очищаем фон

                // Параметры окружности
                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;
                int radius = Math.Min(centerX, centerY) - 50; // Радиус окружности
                float angleStep = (float)(2 * Math.PI / count); // Шаг угла для каждого квадрата

                // Рисуем квадраты
                for (int i = 0; i < count; i++)
                {
                    float angle = i * angleStep;
                    int x = (int)(centerX + radius * Math.Cos(angle));
                    int y = (int)(centerY + radius * Math.Sin(angle));

                    // Размер квадрата
                    int squareSize = 30;

                    // Рисуем квадрат
                    Rectangle square = new Rectangle(x - squareSize / 2, y - squareSize / 2, squareSize, squareSize);
                    g.DrawRectangle(Pens.Blue, square);
                }
            }

            // Устанавливаем изображение в PictureBox
            pictureBox1.Image = bitmap;
        }
    }
}