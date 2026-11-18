using Practice_1.models;
using Practice_1.models.Activity;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Practice_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Выбор файла
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;//путь к файлу
                listBox1.Items.Clear();// очистка старого вывода
                dataGridView1.DataSource = null;// очистка таблицы

                try
                {
                    var content = File.ReadAllText(fileName);// чтение всего файла как строку
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };//чтобы не мешал регистр
                    var data = JsonSerializer.Deserialize<ActivityModel>(content, options);//текст - в обьект C#

                    // Проверяем, есть ли блок с кругами
                    if (data?.DeviceLog?.Windows == null || data.DeviceLog.Windows.Count == 0)
                    {
                        MessageBox.Show("В файле не найдено данных о кругах (Windows).", "Ошибка");
                        return;
                    }

                    var header = data.DeviceLog.Header;// общая информация
                    var windows = data.DeviceLog.Windows;//список кругов

                    // Вывод общей информации
                    listBox1.Items.Add($"Файл: {Path.GetFileName(fileName)}");
                    listBox1.Items.Add($"Дата: {header?.DateTime}");
                    listBox1.Items.Add($"Общая дистанция: {header?.Distance} м");

                    // Формировка данные для таблицы
                    int lapNumber = 1;
                    var tableData = windows
                        .Where(w => w.Window != null) // Берем только те, где есть данные
                        .Select(w => new WindowData //каждый кргу - новая строка
                        {
                            НомерКруга = $"Круг {lapNumber++}",
                            // Время переводим в минуты:секунды
                            Длительность = TimeSpan.FromSeconds(w.Window.Duration).ToString(@"mm\:ss"),
                            Дистанция = $"{w.Window.Distance} м",
                            // Берем среднюю скорость из массива 
                            СредняяСкорость = $"{w.Window.Speed?[0]?.Avg:F2} м/с"
                        }).ToList();

                    // Привязка к таблице
                    dataGridView1.DataSource = tableData;

                    if (dataGridView1.Columns.Count >= 4)
                    {
                        dataGridView1.Columns[0].HeaderText = "Круг";
                        dataGridView1.Columns[1].HeaderText = "Время";
                        dataGridView1.Columns[2].HeaderText = "Дистанция";
                        dataGridView1.Columns[3].HeaderText = "Ср. Скорость";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}