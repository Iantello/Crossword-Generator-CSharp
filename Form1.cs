using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CrosswordGen.CrosswordGenerator;

namespace CrosswordGen
{
    public partial class Form1 : Form
    {
        // Размер поля
        const int GridSize = 20;
        CrosswordGenerator _generator;

        public Form1()
        {
            InitializeComponent();
            _generator = new CrosswordGenerator(GridSize, GridSize);
            InitializeGrid();
            gridCrossword.CellPainting += GridCrossword_CellPainting;
        }

        private void InitializeGrid()
        {
            // Настройка DataGridView
            gridCrossword.ColumnCount = GridSize;
            gridCrossword.RowCount = GridSize;

            // Делаем ячейки квадратными
            for (int i = 0; i < GridSize; i++)
            {
                gridCrossword.Columns[i].Width = 30;
                gridCrossword.Rows[i].Height = 30;
            }

            // Стилизация
            gridCrossword.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridCrossword.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            gridCrossword.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            gridCrossword.DefaultCellStyle.SelectionForeColor = Color.Black;
            gridCrossword.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void DrawBoard()
        {
            // Очистка и подготовка
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    var cell = gridCrossword[x, y];

                    cell.Value = "";             // Очищаем видимый текст
                    cell.Style.BackColor = Color.Black;
                    cell.ReadOnly = true;        // Запрещаем писать в черных клетках
                    cell.Tag = null;             // Очищаем правильный ответ
                }
            }

            // Расстановка "загадок"
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    char letter = _generator.Board[x, y];

                    if (letter != ' ')
                    {
                        var cell = gridCrossword[x, y];

                        cell.Style.BackColor = Color.White;
                        cell.ReadOnly = false;   // Разрешаем писать здесь

                        // ВАЖНО: Прячем правильную букву в свойство Tag
                        cell.Tag = letter.ToString();

                        // Ограничиваем ввод 1 символом (чтобы не писали целые слова в клетку)
                        ((DataGridViewTextBoxCell)cell).MaxInputLength = 1;
                    }
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Создаем список слов с загадками
            var wordList = new List<WordItem>()
    {
        new WordItem("ПРОГРАММА", "Набор инструкций для компьютера"),
        new WordItem("КОМПЬЮТЕР", "Электронное вычислительное устройство"),
        new WordItem("АЛГОРИТМ", "Последовательность действий"),
        new WordItem("СЕРВЕР", "Мощный компьютер, обслуживающий сеть"),
        new WordItem("МЫШЬ", "Манипулятор для управления курсором"),
        new WordItem("ЭКРАН", "Устройство вывода информации"),
        new WordItem("КОД", "Текст программы"),
        new WordItem("СЕТЬ", "Соединение нескольких компьютеров")
    };

            _generator.Generate(wordList);
            DrawBoard();
            ShowClues(); // Новый метод для отображения загадок
        }

        private void ShowClues()
        {
            lstClues.Items.Clear();

            // Сортируем по номерам
            var sortedList = _generator.PlacedWords.OrderBy(w => w.Number).ToList();

            foreach (var item in sortedList)
            {
                string direction = item.IsVertical ? "По верт." : "По гориз.";
                // Формат: "1. (По гориз.) Набор инструкций..."
                string text = $"{item.Number}. ({direction}) {item.Clue}";
                lstClues.Items.Add(text);
            }
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    var cell = gridCrossword[x, y];

                    // Проверяем только белые клетки (у которых есть правильный ответ в Tag)
                    if (cell.Tag != null)
                    {
                        string correctAnswer = cell.Tag.ToString();

                        // Получаем то, что ввел пользователь (защита от пустого ввода)
                        string userAnswer = cell.Value?.ToString().ToUpper();

                        if (string.IsNullOrEmpty(userAnswer))
                        {
                            // Если пусто - красим в белый (или желтый, как предупреждение)
                            cell.Style.BackColor = Color.White;
                        }
                        else if (userAnswer == correctAnswer)
                        {
                            // Правильно - зеленый
                            cell.Style.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            // Ошибка - красный
                            cell.Style.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void GridCrossword_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Рисуем только для ячеек внутри сетки (не заголовки)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // 1. Пусть система нарисует саму ячейку (фон, рамки, текст буквы)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // 2. Теперь рисуем наш номер поверх
                // Ищем, начинается ли какое-то слово в этой клетке
                var wordStartingHere = _generator.PlacedWords
                    .FirstOrDefault(w => w.X == e.ColumnIndex && w.Y == e.RowIndex);

                if (wordStartingHere != null)
                {
                    // Рисуем маленькую цифру в левом верхнем углу
                    using (Brush brush = new SolidBrush(Color.Blue)) // Цвет цифры
                    using (Font font = new Font("Arial", 7)) // Мелкий шрифт
                    {
                        e.Graphics.DrawString(wordStartingHere.Number.ToString(), font, brush, e.CellBounds.X + 2, e.CellBounds.Y + 2);
                    }
                }

                // 3. Говорим системе, что мы сами все нарисовали (чтобы она не перерисовала поверх)
                e.Handled = true;
            }
        }
    }
}