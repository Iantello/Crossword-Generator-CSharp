using System;
using System.Collections.Generic;
using System.Linq;

namespace CrosswordGen
{
    public class CrosswordGenerator
    {
        public char[,] Board;
        public List<WordItem> PlacedWords = new List<WordItem>(); // Теперь храним объекты
        private int _width;
        private int _height;
        private Random _rand = new Random();

        public CrosswordGenerator(int width, int height)
        {
            _width = width;
            _height = height;
            Board = new char[width, height];
        }

        public void Generate(List<WordItem> words)
        {
            // Очистка
            for (int x = 0; x < _width; x++)
                for (int y = 0; y < _height; y++)
                    Board[x, y] = ' ';
            PlacedWords.Clear();

            // Сортируем: сначала длинные слова
            var sortedWords = words.OrderByDescending(w => w.Word.Length).ToList();

            foreach (var item in sortedWords)
            {
                if (PlacedWords.Count == 0)
                    PlaceFirstWord(item);
                else
                    PlaceNextWord(item);
            }

            // ВАЖНО: После генерации расставляем номера (1, 2, 3...)
            // Сортируем слова по положению (сверху-вниз, слева-направо), чтобы нумерация была красивой
            PlacedWords = PlacedWords.OrderBy(w => w.Y).ThenBy(w => w.X).ToList();

            int currentNumber = 1;
            foreach (var word in PlacedWords)
            {
                // Если в этой клетке уже начинается другое слово (пересечение начал), используем тот же номер
                var existing = PlacedWords.FirstOrDefault(w => w != word && w.X == word.X && w.Y == word.Y && w.Number > 0);
                if (existing != null)
                {
                    word.Number = existing.Number;
                }
                else
                {
                    word.Number = currentNumber++;
                }
            }
        }

        // --- Методы размещения (почти такие же, но работают с WordItem) ---

        private void PlaceFirstWord(WordItem item)
        {
            int startX = _width / 2 - item.Word.Length / 2;
            int startY = _height / 2;
            PlaceWordOnBoard(item, startX, startY, 0);
        }

        private void PlaceNextWord(WordItem item)
        {
            var possiblePositions = new List<Tuple<int, int, int>>();
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (CanPlaceWord(item.Word, x, y, 0)) possiblePositions.Add(Tuple.Create(x, y, 0));
                    if (CanPlaceWord(item.Word, x, y, 1)) possiblePositions.Add(Tuple.Create(x, y, 1));
                }
            }

            if (possiblePositions.Count > 0)
            {
                var best = possiblePositions[_rand.Next(possiblePositions.Count)];
                PlaceWordOnBoard(item, best.Item1, best.Item2, best.Item3);
            }
        }

        // Метод CanPlaceWord оставляем без изменений (как в прошлом ответе)
        private bool CanPlaceWord(string word, int x, int y, int direction)
        {
            // ... (Вставьте сюда код CanPlaceWord из прошлого ответа) ...
            // Для экономии места я его не дублирую, он не меняется.
            // Только убедитесь, что он у вас есть!

            // --- КОПИЯ ИЗ ПРОШЛОГО ОТВЕТА ДЛЯ УДОБСТВА ---
            if (direction == 0 && (x + word.Length > _width)) return false;
            if (direction == 1 && (y + word.Length > _height)) return false;

            bool hasIntersection = false;
            for (int i = 0; i < word.Length; i++)
            {
                int cx = x + (direction == 0 ? i : 0);
                int cy = y + (direction == 1 ? i : 0);
                char currentCell = Board[cx, cy];

                if (currentCell == ' ')
                {
                    if (direction == 0)
                    {
                        if (cy > 0 && Board[cx, cy - 1] != ' ') return false;
                        if (cy < _height - 1 && Board[cx, cy + 1] != ' ') return false;
                    }
                    else
                    {
                        if (cx > 0 && Board[cx - 1, cy] != ' ') return false;
                        if (cx < _width - 1 && Board[cx + 1, cy] != ' ') return false;
                    }
                }
                else if (currentCell == word[i]) // Внимание: здесь item.Word[i] или word[i]
                {
                    hasIntersection = true;
                }
                else return false;
            }

            // Проверка краев
            int beforeX = x - (direction == 0 ? 1 : 0);
            int beforeY = y - (direction == 1 ? 1 : 0);
            if (beforeX >= 0 && beforeY >= 0 && Board[beforeX, beforeY] != ' ') return false;
            int afterX = x + (direction == 0 ? word.Length : 0);
            int afterY = y + (direction == 1 ? word.Length : 0);
            if (afterX < _width && afterY < _height && Board[afterX, afterY] != ' ') return false;

            return hasIntersection;
            // -----------------------------------------------
        }

        private void PlaceWordOnBoard(WordItem item, int x, int y, int direction)
        {
            for (int i = 0; i < item.Word.Length; i++)
            {
                int cx = x + (direction == 0 ? i : 0);
                int cy = y + (direction == 1 ? i : 0);
                Board[cx, cy] = item.Word[i];
            }

            // Сохраняем данные о размещении
            item.X = x;
            item.Y = y;
            item.IsVertical = (direction == 1);
            PlacedWords.Add(item);
        }
        public class WordItem
        {
            public string Word { get; set; }
            public string Clue { get; set; } // Загадка

            // Данные о расположении (заполняются генератором)
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsVertical { get; set; }
            public int Number { get; set; } // Номер вопроса (1, 2, 3...)

            public WordItem(string word, string clue)
            {
                Word = word.ToUpper();
                Clue = clue;
            }
        }
    }
}