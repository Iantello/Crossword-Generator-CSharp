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
        private List<WordItem> userDictionary = new List<WordItem>();

        // Лимит слов
        private const int MaxWords = 20;

        // Размер поля
        const int GridSize = 20;
        CrosswordGenerator _generator;

        public Form1()
        {
            // Обязательно первая строчка!
            InitializeComponent();

            // Обновляем счетчик слов при запуске (из первого твоего варианта)
            UpdateWordCount();

            // Инициализируем генератор и сетку (из второго твоего варианта)
            _generator = new CrosswordGenerator(GridSize, GridSize);
            InitializeGrid();
            gridCrossword.CellPainting += GridCrossword_CellPainting;
        }

        private void UpdateWordCount()
        {
            lblWordCount.Text = $"Слов: {userDictionary.Count}/{MaxWords}";
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
            // 1. Проверяем, добавил ли пользователь хотя бы пару слов в словарь
            if (userDictionary.Count < 2)
            {
                MessageBox.Show("Добавьте хотя бы 2 слова для создания кроссворда!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Создаем wordList на основе слов, которые ввел пользователь
            var wordList = new List<WordItem>(userDictionary);

            // --- ВОТ ЭТИХ СТРОК НЕ ХВАТАЛО ---

            // 3. Запускаем алгоритм генерации кроссворда, передавая ему наши слова
            _generator.Generate(wordList);

            // 4. Отрисовываем сетку кроссворда на экране (твой готовый метод)
            DrawBoard();

            // 5. Выводим список загадок сбоку (твой готовый метод)
            ShowClues();
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

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            // 1. Получаем текст из текстовых полей (убираем лишние пробелы по краям)
            // Слово сразу делаем ЗАГЛАВНЫМИ буквами, как на твоем скриншоте
            string word = txtWord.Text.Trim().ToUpper();
            string clue = txtClue.Text.Trim();

            // 2. Проверяем лимит (не больше 20 слов)
            if (userDictionary.Count >= 20)
            {
                MessageBox.Show("Достигнут максимальный лимит в 20 слов!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Проверяем, что пользователь не оставил поля пустыми
            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(clue))
            {
                MessageBox.Show("Пожалуйста, введите и слово, и загадку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Проверяем, нет ли уже такого слова в словаре (чтобы избежать дубликатов)
            // ВАЖНО: Если в твоем классе WordItem само слово хранится не в свойстве .Word, 
            // а, например, в .Text, то замени w.Word на w.Text
            if (userDictionary.Any(w => w.Word == word))
            {
                MessageBox.Show("Такое слово уже добавлено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. САМОЕ ГЛАВНОЕ: Создаем объект ТВОЕГО класса WordItem
            WordItem newItem = new WordItem(word, clue);

            // 6. Добавляем его в наш внутренний список (словарь)
            userDictionary.Add(newItem);

            // 7. Добавляем текст в ListBox, чтобы пользователь видел, что он добавил
            listBoxDictionary.Items.Add($"{word} - {clue}");

            // 8. Обновляем текст на Label со счетчиком слов (если ты его создал)
            lblWordCount.Text = $"Слов: {userDictionary.Count}/20";

            // 9. Очищаем текстовые поля, чтобы было удобно вводить следующее слово
            txtWord.Clear();
            txtClue.Clear();
            txtWord.Focus(); // Возвращаем мигающий курсор обратно в поле ввода слова
        }

        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
            if (listBoxDictionary.SelectedIndex != -1)
            {
                int index = listBoxDictionary.SelectedIndex;
                userDictionary.RemoveAt(index);
                listBoxDictionary.Items.RemoveAt(index);
                UpdateWordCount();
            }
        }
    }
}