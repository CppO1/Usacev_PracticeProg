using Practice_OOP.models.Activity;
using Practice_OOP.models;
using Practice_OOP.Services;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Practice_OOP // ВАЖНО: Твой новый namespace
{
    public partial class Form1 : Form
    {
        private readonly WorkoutService _workoutService;
        private Workout _currentWorkout; // Временное хранилище для загруженного JSON

        // 1. Внедряем сервис через конструктор (Dependency Injection)
        public Form1(WorkoutService workoutService)
        {
            InitializeComponent();
            _workoutService = workoutService;

            // При запуске формы загружаем список сохраненных тренировок в верхнюю таблицу
            LoadWorkoutsTable();
        }

        // 2. ЗАГРУЗКА JSON (почти как в первой практике, но данные сохраняем в _currentWorkout)
        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                listBox1.Items.Clear();
                dataGridViewLaps.DataSource = null;

                try
                {
                    var content = File.ReadAllText(fileName);
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var data = JsonSerializer.Deserialize<ActivityModel>(content, options);

                    if (data?.DeviceLog?.Windows == null || data.DeviceLog.Windows.Count == 0)
                    {
                        MessageBox.Show("В файле не найдено данных о кругах.", "Ошибка");
                        return;
                    }

                    var header = data.DeviceLog.Header;
                    var windows = data.DeviceLog.Windows;

                    // Вывод общей информации в список
                    listBox1.Items.Add($"Файл: {Path.GetFileName(fileName)}");
                    listBox1.Items.Add($"Дата: {header?.DateTime}");
                    listBox1.Items.Add($"Общая дистанция: {header?.Distance} м");

                    // Формируем объект Workout для сохранения в БД
                    _currentWorkout = new Workout
                    {
                        FileName = Path.GetFileName(fileName),
                        Time = header.DateTime,
                        Distance = header.Distance
                    };

                    // Перебираем круги и добавляем в модель БД
                    foreach (var w in windows.Where(w => w.Window != null))
                    {
                        _currentWorkout.Laps.Add(new WorkoutLap
                        {
                            DateTime = header.DateTime,
                            Distance = w.Window.Distance,
                            Duration = w.Window.Duration,
                            AverageSpeed = w.Window.Speed?[0]?.Avg ?? 0
                        });
                    }

                    // Выводим прочитанные круги в нижнюю таблицу
                    dataGridViewLaps.DataSource = _currentWorkout.Laps.Select(l => new
                    {
                        Дата_и_время = l.DateTime,
                        Дистанция = $"{l.Distance} м",
                        Продолжительность = TimeSpan.FromSeconds(l.Duration).ToString(@"mm\:ss"),
                        Скорость = $"{l.AverageSpeed:F2} м/с"
                    }).ToList();

                    MessageBox.Show("Файл прочитан. Теперь нажмите 'Файл; Сохранить в БД'.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                }
            }
        }

        // 3. СОХРАНЕНИЕ В БД
        private void сохранитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentWorkout == null)
            {
                MessageBox.Show("Сначала загрузите JSON-файл тренировки!");
                return;
            }

            try
            {
                _workoutService.AddWorkout(_currentWorkout); // Сохраняем через сервис
                MessageBox.Show("Тренировка сохранена в БД!");
                _currentWorkout = null; // Очищаем, чтобы не было дублей
                LoadWorkoutsTable(); // Обновляем верхнюю таблицу
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        // 4. ЗАГРУЗКА ВЕРХНЕЙ ТАБЛИЦЫ (Все тренировки из БД)
        private void LoadWorkoutsTable()
        {
            var workouts = _workoutService.GetAllWorkouts();
            dataGridViewWorkouts.DataSource = workouts.Select(w => new
            {
                w.Id,
                w.FileName,
                w.Time,
                w.Distance
            }).ToList();
        }

        // 5. ПРОСМОТР ТРЕНИРОВКИ (Клик по верхней таблице)
        private void dataGridViewWorkouts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int workoutId = Convert.ToInt32(dataGridViewWorkouts.Rows[e.RowIndex].Cells[0].Value);

                var workout = _workoutService.GetWorkoutById(workoutId);

                if (workout != null)
                {
                    // Заполняем TextBox общей информацией
                    textBoxGeneralInfo.Text = $"Имя файла: {workout.FileName}\r\n" +
                                              $"Дистанция: {workout.Distance} м\r\n" +
                                              $"Время тренировки: {workout.Time}";

                    // Заполняем нижнюю таблицу кругами
                    dataGridViewLaps.DataSource = workout.Laps.Select(l => new
                    {
                        Дата_и_время = l.DateTime,
                        Дистанция = $"{l.Distance} м",
                        Продолжительность = TimeSpan.FromSeconds(l.Duration).ToString(@"mm\:ss"),
                        Скорость = $"{l.AverageSpeed:F2} м/с"
                    }).ToList();
                }
            }
        }

        // Заглушки для старых событий, чтобы не было ошибок
        private void label1_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}