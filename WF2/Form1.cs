using System;
using System.Windows.Forms;

namespace WF2
{
    public partial class Form1 : Form
    {
        private int buttonCount = 1;   // Счетчик кнопок
        private int labelCount = 1;    // Счетчик меток
        private int textBoxCount = 1;  // Счетчик полей ввода

        public Form1()
        {
            InitializeComponent();

            // Настройка исходных элементов
            btnCreateButton.Text = "Создать кнопку";
            lblCreateLabel.Text = "Создать метку";
            txtCreateTextBox.Text = "Создать поле";

            // Подписываемся на события
            btnCreateButton.Click += CreateButton_Click;
            lblCreateLabel.Click += CreateLabel_Click;
            txtCreateTextBox.Click += CreateTextBox_Click;
        }

        // Создание новой кнопки
        private void CreateButton_Click(object sender, EventArgs e)
        {
            CreateNewButton();
        }

        // Создание новой метки
        private void CreateLabel_Click(object sender, EventArgs e)
        {
            CreateNewLabel();
        }

        // Создание нового поля ввода
        private void CreateTextBox_Click(object sender, EventArgs e)
        {
            CreateNewTextBox();
        }

        // Метод создания кнопки
        private void CreateNewButton()
        {
            Button newButton = new Button
            {
                Text = $"Кнопка {buttonCount + 1}",
                Location = new System.Drawing.Point(50, 50 + buttonCount * 30),
                Size = new System.Drawing.Size(120, 25)
            };
            Controls.Add(newButton);
            newButton.Click += CreateButton_Click; // Передаем обработчик
            buttonCount++;
            UpdateCounters();
        }

        // Метод создания метки
        private void CreateNewLabel()
        {
            Label newLabel = new Label
            {
                Text = $"Метка {labelCount + 1}",
                Location = new System.Drawing.Point(200, 50 + labelCount * 30),
                Size = new System.Drawing.Size(120, 25)
            };
            Controls.Add(newLabel);
            labelCount++;
            UpdateCounters();
        }

        // Метод создания поля ввода
        private void CreateNewTextBox()
        {
            TextBox newTextBox = new TextBox
            {
                Text = $"Поле {textBoxCount + 1}",
                Location = new System.Drawing.Point(350, 50 + textBoxCount * 30),
                Size = new System.Drawing.Size(120, 25)
            };
            Controls.Add(newTextBox);
            textBoxCount++;
            UpdateCounters();
        }

        // Обновление счетчиков
        private void UpdateCounters()
        {
            lblButtonCount.Text = $"Кнопки: {buttonCount}";
            lblLabelCount.Text = $"Метки: {labelCount}";
            lblTextBoxCount.Text = $"Поля: {textBoxCount}";
        }
    }
}