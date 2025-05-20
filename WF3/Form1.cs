using System;
using System.Drawing;
using System.Windows.Forms;

namespace WF3
{
    public partial class Form1 : Form
    {
        private const double ScaleX = 30; // Масштаб по оси X
        private const double ScaleY = 20; // Масштаб по оси Y

        // Поля для хранения данных графика
        private double _a = double.NaN;
        private double _b = double.NaN;
        private double _c = double.NaN;

        public Form1()
        {
            InitializeComponent();

            // Подписка на события
            
            pictureBox1.Paint += pictureBox1_Paint;
            Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate(); // Перерисовка при изменении размера
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            if (!ParseInputs(out double a, out double b, out double c))
                return;

            // Сохранение значений для отрисовки
            _a = a;
            _b = b;
            _c = c;

            pictureBox1.Invalidate(); // Инициируем перерисовку
            FindMinimum(a, b, c);
        }

        private bool ParseInputs(out double a, out double b, out double c)
        {
            a = b = c = 0;

            if (!double.TryParse(textBoxA.Text, out a) ||
                !double.TryParse(textBoxB.Text, out b) ||
                !double.TryParse(textBoxC.Text, out c))
            {
                MessageBox.Show("Ошибка: Все значения должны быть числами");
                return false;
            }

            return true;
        }

        private void FindMinimum(double a, double b, double c)
        {
            double f(double x) => Math.Sin(x) + Math.Cos(2 * x);

            double va = f(a), vb = f(b), vc = f(c);
            double min = Math.Min(va, Math.Min(vb, vc));

            string result = "";
            if (va == min) result += $"a={a:F2}: {va:F4}\n";
            if (vb == min) result += $"b={b:F2}: {vb:F4}\n";
            if (vc == min) result += $"c={c:F2}: {vc:F4}\n";

            MessageBox.Show($"Минимальное значение в точках:\n{result}");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Не рисуем, если данные не заданы
            if (double.IsNaN(_a) || double.IsNaN(_b) || double.IsNaN(_c))
                return;

            var g = e.Graphics;
            var pictureBox = (PictureBox)sender;
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            // Оси координат
            using (Pen axisPen = new Pen(Color.LightGray, 1))
            {
                g.DrawLine(axisPen, 0, height / 2, width, height / 2); // Ось X
                g.DrawLine(axisPen, width / 2, 0, width / 2, height); // Ось Y
            }

            // График функции
            using (Pen functionPen = new Pen(Color.Blue, 2))
            {
                Point previousPoint = new Point();
                for (double x = -10; x <= 10; x += 0.1)
                {
                    double y = Math.Sin(x) + Math.Cos(2 * x);
                    int px = (int)(width / 2 + x * ScaleX);
                    int py = (int)(height / 2 - y * ScaleY);

                    if (x == -10)
                    {
                        previousPoint = new Point(px, py);
                        continue;
                    }

                    g.DrawLine(functionPen, previousPoint, new Point(px, py));
                    previousPoint = new Point(px, py);

                    // Отображение точек a, b, c
                    if (Math.Abs(x - _a) < 0.05 ||
                        Math.Abs(x - _b) < 0.05 ||
                        Math.Abs(x - _c) < 0.05)
                    {
                        g.FillEllipse(Brushes.Red, px - 3, py - 3, 6, 6);
                    }
                }
            }
        }
    }
}