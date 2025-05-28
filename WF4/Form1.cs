using System;
using System.Windows.Forms;

namespace WF4
{
    public partial class Form1 : Form
    {
        private int[] array = new int[100];
        private int[] originalArray;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            GenerateRandomArray();
            DisplayArray(originalArray, "Исходный массив:");
        }

        private void GenerateRandomArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 1000); // Числа от 1 до 999
            }

            originalArray = new int[array.Length];
            Array.Copy(array, originalArray, array.Length);
        }

        private void DisplayArray(int[] arr, string title)
        {
            listBoxResults.Items.Add(title);

            // Преобразуем массив в строку с пробелами
            string arrayLine = string.Join(" ", arr);

            // Разбиваем на строки по 100 символов
            int maxLineLength = 50;
            for (int i = 0; i < arrayLine.Length; i += maxLineLength)
            {
                int length = Math.Min(maxLineLength, arrayLine.Length - i);
                listBoxResults.Items.Add(arrayLine.Substring(i, length));
            }

            listBoxResults.Items.Add(""); // Пустая строка между блоками
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxSearch.Text))
                {
                    MessageBox.Show("Введите значение для поиска!");
                    return;
                }

                int searchValue = int.Parse(textBoxSearch.Text);

                // Очищаем список перед новым выводом
                listBoxResults.Items.Clear();

                // Вывод оригинального массива
                DisplayArray(originalArray, "Исходный массив:");

                // Линейный поиск
                int linearIterations = LinearSearch(searchValue);
                listBoxResults.Items.Add($"Линейный поиск: значение {searchValue} найдено за {linearIterations} итераций.");

                // Быстрая сортировка
                QuickSort(array, 0, array.Length - 1);

                // Вывод отсортированного массива
                DisplayArray(array, "Отсортированный массив:");

                // Бинарный поиск
                int binaryIterations = BinarySearch(searchValue);
                listBoxResults.Items.Add($"Бинарный поиск: значение {searchValue} найдено за {binaryIterations} итераций.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private int LinearSearch(int value)
        {
            int iterations = 0;
            for (int i = 0; i < originalArray.Length; i++)
            {
                iterations++;
                if (originalArray[i] == value)
                {
                    return iterations;
                }
            }
            return iterations; // Элемент не найден
        }

        private int BinarySearch(int value)
        {
            int left = 0;
            int right = array.Length - 1;
            int iterations = 0;

            while (left <= right)
            {
                iterations++;
                int mid = left + (right - left) / 2;

                if (array[mid] == value)
                {
                    return iterations;
                }
                else if (array[mid] < value)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return iterations; // Элемент не найден
        }

        private void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(ref arr[i], ref arr[j]);
                }
            }
            Swap(ref arr[i + 1], ref arr[high]);
            return i + 1;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}