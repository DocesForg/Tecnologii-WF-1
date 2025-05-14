using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WF1
{
    public partial class Form1 : Form
    {
        private Button[] buttons;
        private Dictionary<Button, List<Button>> buttonActions; // ����� ������ ������ �����
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            buttons = new Button[] { button1, button2, button3, button4, button5 };
            buttonActions = new Dictionary<Button, List<Button>>();

            RestartGame(); // ������ ����� ����

            foreach (var btn in buttons)
            {
                btn.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;

            // ����������� ��������� ���� ������ �� ������ ��������
            foreach (var targetButton in buttonActions[clickedButton])
            {
                targetButton.Visible = !targetButton.Visible;
            }

            // ��������� ������
            if (!AnyButtonVisible())
            {
                MessageBox.Show("�����������! �� ��������!", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RestartGame();
            }
        }

        private bool AnyButtonVisible()
        {
            foreach (var btn in buttons)
            {
                if (btn.Visible) return true;
            }
            return false;
        }

        private void RestartGame()
        {
            // ��������������� ��� ������
            foreach (var btn in buttons)
            {
                btn.Visible = true;
            }

            // ���������� ����� ��������� �������� ��� ������ ������
            GenerateRandomButtonActions();
        }

        private void GenerateRandomButtonActions()
        {
            bool isValid = false;

            while (!isValid)
            {
                buttonActions.Clear();

                for (int i = 0; i < buttons.Length; i++)
                {
                    var currentButton = buttons[i];
                    var allButtons = new List<Button>(buttons); // ������ ������� � ���� ������

                    int minCount = 1; // ������ ������ ������ ������ ���� �� �� ����
                    int maxCount = allButtons.Count;
                    int actionCount = random.Next(minCount, maxCount + 1);

                    var affectedButtons = new List<Button>();
                    while (affectedButtons.Count < actionCount)
                    {
                        int index = random.Next(allButtons.Count);
                        affectedButtons.Add(allButtons[index]);
                        allButtons.RemoveAt(index);
                    }

                    buttonActions[currentButton] = affectedButtons;
                }

                isValid = IsGraphConnected() && CanAllBeHiddenInSequence();
            }
        }

        // ���������, ��� ��� ������ ����� ���� �������� �����-�� �������
        private bool CanAllBeHiddenInSequence()
        {
            HashSet<Button> canBeToggled = new HashSet<Button>();

            foreach (var pair in buttonActions)
            {
                foreach (var btn in pair.Value)
                {
                    canBeToggled.Add(btn);
                }
            }

            return canBeToggled.Count == buttons.Length;
        }

        // ��������� ��������� ����� (����� ��������� �� ���� �����)
        private bool IsGraphConnected()
        {
            HashSet<Button> visited = new HashSet<Button>();
            Stack<Button> stack = new Stack<Button>();

            stack.Push(buttons[0]);
            visited.Add(buttons[0]);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                foreach (var neighbor in buttonActions[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        stack.Push(neighbor);
                    }
                }
            }

            return visited.Count == buttons.Length;
        }
    }
}