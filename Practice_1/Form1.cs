using Practice_OOP.models;
using Practice_OOP.models.Activity;
using Practice_OOP.Services;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Practice_OOP
{
    public partial class Form1 : Form
    {
        // Обобщенный серивис для работы с двумя сущностями
        private readonly Service<Workout> _workoutService;
        private readonly Service<WorkoutLap> _lapService;

        private Workout _currentWorkout;
        private int _selectedWorkoutId = -1; // Записать ID выбранной тренировки

        public Form1(Service<Workout> workoutService, Service<WorkoutLap> lapService)
        {
            InitializeComponent();
            _workoutService = workoutService;
            _lapService = lapService;

            // Настройка ComboBox для фильтрации кругов
            comboBoxFilter.Items.Clear();
            comboBoxFilter.Items.Add("Все круги");
            comboBoxFilter.Items.Add("Длительность > 5 мин");
            comboBoxFilter.Items.Add("Дистанция > 1000 м");
            comboBoxFilter.SelectedIndex = 0;

            LoadWorkoutsTable();
        }

        // 1. Загрузка json
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

                    listBox1.Items.Add($"Файл: {Path.GetFileName(fileName)}");
                    listBox1.Items.Add($"Дата: {header?.DateTime}");
                    listBox1.Items.Add($"Общая дистанция: {header?.Distance} м");

                    _currentWorkout = new Workout
                    {
                        FileName = Path.GetFileName(fileName),
                        Time = header.DateTime,
                        Distance = header.Distance
                    };

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

                    // Выводим в таблицу то, что загрузили
                    ShowLapsInTable(_currentWorkout.Laps);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                }
            }
        }

        // 2. Сохранение в БД
        private void сохранитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentWorkout == null)
            {
                MessageBox.Show("Сначала загрузите JSON-файл тренировки!");
                return;
            }

            try
            {
                _workoutService.Add(_currentWorkout); // Используем обобщенный метод Add
                MessageBox.Show("Тренировка сохранена в БД!");
                _currentWorkout = null;
                LoadWorkoutsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        // 3. Загрузка всех тренировок
        private void LoadWorkoutsTable()
        {
            var workouts = _workoutService.GetAll();
            dataGridViewWorkouts.DataSource = workouts.Select(w => new
            {
                w.Id,
                w.FileName,
                w.Time,
                w.Distance
            }).ToList();
        }

        // 4. Просмотр тренировки
        private void dataGridViewWorkouts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedWorkoutId = Convert.ToInt32(dataGridViewWorkouts.Rows[e.RowIndex].Cells[0].Value);

                var workout = _workoutService.GetById(_selectedWorkoutId);

                if (workout != null)
                {
                    textBoxGeneralInfo.Text = $"Имя файла: {workout.FileName}\r\n" +
                                              $"Дистанция: {workout.Distance} м\r\n" +
                                              $"Время тренировки: {workout.Time}";

                    // При клике на новую тренировку сбрасываем фильтр на "Все круги"
                    comboBoxFilter.SelectedIndex = 0;

                    // Загружаем все круги для этой тренировки
                    var laps = _lapService.Get(x => x.WorkoutId == _selectedWorkoutId);
                    ShowLapsInTable(laps);
                }
            }
        }

        // 5. Фильтрация кругов
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if (_selectedWorkoutId == -1)
            {
                MessageBox.Show("Сначала выберите тренировку в правой таблице!");
                return;
            }

            // 1. Если выбрано "Все круги"
            if (comboBoxFilter.SelectedIndex == 0)
            {
                var laps = _lapService.Get(x => x.WorkoutId == _selectedWorkoutId);
                ShowLapsInTable(laps);
            }
            // 2. Если выбрано "Длительность > 5 мин" 
            else if (comboBoxFilter.SelectedIndex == 1)
            {
                //  условие через лямбда-выражение
                var filteredLaps = _lapService.Get(x => x.WorkoutId == _selectedWorkoutId && x.Duration > 300);
                ShowLapsInTable(filteredLaps);
            }
            // 3. Если выбрано "Дистанция > 1000 м"
            else if (comboBoxFilter.SelectedIndex == 2)
            {
                //  условие через лямбда-выражение
                var filteredLaps = _lapService.Get(x => x.WorkoutId == _selectedWorkoutId && x.Distance > 1000);
                ShowLapsInTable(filteredLaps);
            }
        }

        // Вспомогательный метод для красивого вывода кругов в таблицу
        private void ShowLapsInTable(System.Collections.Generic.List<WorkoutLap> laps)
        {
            dataGridViewLaps.DataSource = laps.Select(l => new
            {
                Дата_и_время = l.DateTime,
                Дистанция = $"{l.Distance} м",
                Продолжительность = TimeSpan.FromSeconds(l.Duration).ToString(@"mm\:ss"),
                Скорость = $"{l.AverageSpeed:F2} м/с"
            }).ToList();
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}