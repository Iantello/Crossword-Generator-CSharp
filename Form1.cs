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

        private const int MaxWords = 20;

        const int GridSize = 20;
        CrosswordGenerator _generator;

        public Form1()
        {
            InitializeComponent();

            UpdateWordCount();

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
            gridCrossword.ColumnCount = GridSize;
            gridCrossword.RowCount = GridSize;

            for (int i = 0; i < GridSize; i++)
            {
                gridCrossword.Columns[i].Width = 30;
                gridCrossword.Rows[i].Height = 30;
            }

            gridCrossword.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridCrossword.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            gridCrossword.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            gridCrossword.DefaultCellStyle.SelectionForeColor = Color.Black;
            gridCrossword.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void DrawBoard()
        {
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    var cell = gridCrossword[x, y];

                    cell.Value = "";
                    cell.Style.BackColor = Color.Black;
                    cell.ReadOnly = true;
                    cell.Tag = null;
                }
            }

            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    char letter = _generator.Board[x, y];

                    if (letter != ' ')
                    {
                        var cell = gridCrossword[x, y];

                        cell.Style.BackColor = Color.White;
                        cell.ReadOnly = false;

                        cell.Tag = letter.ToString();

                        ((DataGridViewTextBoxCell)cell).MaxInputLength = 1;
                    }
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (userDictionary.Count < 2)
            {
                MessageBox.Show("Добавьте хотя бы 2 слова для создания кроссворда!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var wordList = new List<WordItem>(userDictionary);

            _generator.Generate(wordList);

            DrawBoard();

            ShowClues();

            gridCrossword.ClearSelection();
        }

        private void ShowClues()
        {
            lstClues.Clear();

            var sortedList = _generator.PlacedWords.OrderBy(w => w.Number).ToList();

            foreach (var item in sortedList)
            {
                string direction = item.IsVertical ? "По верт." : "По гориз.";
                string text = $"{item.Number}. ({direction}) {item.Clue}";
                lstClues.AppendText(text + Environment.NewLine + Environment.NewLine);
            }
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            gridCrossword.EndEdit();

            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    var cell = gridCrossword[x, y];

                    if (cell.Tag != null)
                    {
                        string correctAnswer = cell.Tag.ToString();

                        string userAnswer = cell.Value?.ToString().ToUpper();

                        if (string.IsNullOrEmpty(userAnswer))
                        {
                            cell.Style.BackColor = Color.White;
                        }
                        else if (userAnswer == correctAnswer)
                        {
                            cell.Style.BackColor = Color.LightGreen;
                            cell.Style.SelectionBackColor = Color.LightGreen;
                        }
                        else
                        {
                            cell.Style.BackColor = Color.LightPink;
                            cell.Style.SelectionBackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void GridCrossword_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var wordStartingHere = _generator.PlacedWords
                    .FirstOrDefault(w => w.X == e.ColumnIndex && w.Y == e.RowIndex);

                if (wordStartingHere != null)
                {
                    using (Brush brush = new SolidBrush(Color.Blue))
                    using (Font font = new Font("Arial", 7))
                    {
                        e.Graphics.DrawString(wordStartingHere.Number.ToString(), font, brush, e.CellBounds.X + 2, e.CellBounds.Y + 2);
                    }
                }

                e.Handled = true;
            }
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            string word = txtWord.Text.Trim().ToUpper();
            string clue = txtClue.Text.Trim();

            if (userDictionary.Count >= 20)
            {
                MessageBox.Show("Достигнут максимальный лимит в 20 слов!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(clue))
            {
                MessageBox.Show("Пожалуйста, введите и слово, и загадку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userDictionary.Any(w => w.Word == word))
            {
                MessageBox.Show("Такое слово уже добавлено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            WordItem newItem = new WordItem(word, clue);

            userDictionary.Add(newItem);

            listBoxDictionary.Items.Add(new MaterialSkin.MaterialListBoxItem($"{word} - {clue}"));

            lblWordCount.Text = $"Слов: {userDictionary.Count}/20";

            txtWord.Clear();
            txtClue.Clear();
            txtWord.Focus();
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