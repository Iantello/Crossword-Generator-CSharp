namespace CrosswordGen
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridCrossword = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWordCount = new System.Windows.Forms.Label();
            this.lstClues = new MaterialSkin.Controls.MaterialListBox();
            this.txtWord = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtClue = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnAddWord = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveWord = new MaterialSkin.Controls.MaterialButton();
            this.btnGenerate = new MaterialSkin.Controls.MaterialButton();
            this.btnCheck = new MaterialSkin.Controls.MaterialButton();
            this.listBoxDictionary = new MaterialSkin.Controls.MaterialListBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrossword)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCrossword
            // 
            this.gridCrossword.AllowUserToAddRows = false;
            this.gridCrossword.AllowUserToDeleteRows = false;
            this.gridCrossword.AllowUserToResizeColumns = false;
            this.gridCrossword.AllowUserToResizeRows = false;
            this.gridCrossword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCrossword.ColumnHeadersVisible = false;
            this.gridCrossword.Location = new System.Drawing.Point(12, 12);
            this.gridCrossword.Name = "gridCrossword";
            this.gridCrossword.RowHeadersVisible = false;
            this.gridCrossword.Size = new System.Drawing.Size(680, 770);
            this.gridCrossword.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(699, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Загадки:";
            // 
            // lblWordCount
            // 
            this.lblWordCount.AutoSize = true;
            this.lblWordCount.Location = new System.Drawing.Point(698, 525);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(35, 13);
            this.lblWordCount.TabIndex = 10;
            this.lblWordCount.Text = "label2";
            // 
            // lstClues
            // 
            this.lstClues.BackColor = System.Drawing.Color.White;
            this.lstClues.BorderColor = System.Drawing.Color.LightGray;
            this.lstClues.Depth = 0;
            this.lstClues.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstClues.Location = new System.Drawing.Point(702, 35);
            this.lstClues.MouseState = MaterialSkin.MouseState.HOVER;
            this.lstClues.Name = "lstClues";
            this.lstClues.SelectedIndex = -1;
            this.lstClues.SelectedItem = null;
            this.lstClues.Size = new System.Drawing.Size(290, 357);
            this.lstClues.TabIndex = 11;
            // 
            // txtWord
            // 
            this.txtWord.AnimateReadOnly = false;
            this.txtWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtWord.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtWord.Depth = 0;
            this.txtWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtWord.HideSelection = true;
            this.txtWord.LeadingIcon = null;
            this.txtWord.Location = new System.Drawing.Point(702, 398);
            this.txtWord.MaxLength = 32767;
            this.txtWord.MouseState = MaterialSkin.MouseState.OUT;
            this.txtWord.Name = "txtWord";
            this.txtWord.PasswordChar = '\0';
            this.txtWord.PrefixSuffixText = null;
            this.txtWord.ReadOnly = false;
            this.txtWord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWord.SelectedText = "";
            this.txtWord.SelectionLength = 0;
            this.txtWord.SelectionStart = 0;
            this.txtWord.ShortcutsEnabled = true;
            this.txtWord.Size = new System.Drawing.Size(290, 36);
            this.txtWord.TabIndex = 12;
            this.txtWord.TabStop = false;
            this.txtWord.Text = "Введите слово";
            this.txtWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtWord.TrailingIcon = null;
            this.txtWord.UseSystemPasswordChar = false;
            this.txtWord.UseTallSize = false;
            // 
            // txtClue
            // 
            this.txtClue.AnimateReadOnly = false;
            this.txtClue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtClue.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtClue.Depth = 0;
            this.txtClue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtClue.HideSelection = true;
            this.txtClue.LeadingIcon = null;
            this.txtClue.Location = new System.Drawing.Point(702, 440);
            this.txtClue.MaxLength = 32767;
            this.txtClue.MouseState = MaterialSkin.MouseState.OUT;
            this.txtClue.Name = "txtClue";
            this.txtClue.PasswordChar = '\0';
            this.txtClue.PrefixSuffixText = null;
            this.txtClue.ReadOnly = false;
            this.txtClue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtClue.SelectedText = "";
            this.txtClue.SelectionLength = 0;
            this.txtClue.SelectionStart = 0;
            this.txtClue.ShortcutsEnabled = true;
            this.txtClue.Size = new System.Drawing.Size(290, 36);
            this.txtClue.TabIndex = 13;
            this.txtClue.TabStop = false;
            this.txtClue.Text = "Введите загадку";
            this.txtClue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtClue.TrailingIcon = null;
            this.txtClue.UseSystemPasswordChar = false;
            this.txtClue.UseTallSize = false;
            // 
            // btnAddWord
            // 
            this.btnAddWord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddWord.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddWord.Depth = 0;
            this.btnAddWord.HighEmphasis = true;
            this.btnAddWord.Icon = null;
            this.btnAddWord.Location = new System.Drawing.Point(743, 485);
            this.btnAddWord.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddWord.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddWord.Size = new System.Drawing.Size(100, 36);
            this.btnAddWord.TabIndex = 14;
            this.btnAddWord.Text = "Добавить";
            this.btnAddWord.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddWord.UseAccentColor = false;
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnRemoveWord
            // 
            this.btnRemoveWord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveWord.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRemoveWord.Depth = 0;
            this.btnRemoveWord.HighEmphasis = true;
            this.btnRemoveWord.Icon = null;
            this.btnRemoveWord.Location = new System.Drawing.Point(851, 485);
            this.btnRemoveWord.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveWord.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveWord.Name = "btnRemoveWord";
            this.btnRemoveWord.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRemoveWord.Size = new System.Drawing.Size(91, 36);
            this.btnRemoveWord.TabIndex = 15;
            this.btnRemoveWord.Text = "Удалить";
            this.btnRemoveWord.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemoveWord.UseAccentColor = false;
            this.btnRemoveWord.UseVisualStyleBackColor = true;
            this.btnRemoveWord.Click += new System.EventHandler(this.btnRemoveWord_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGenerate.Depth = 0;
            this.btnGenerate.HighEmphasis = true;
            this.btnGenerate.Icon = null;
            this.btnGenerate.Location = new System.Drawing.Point(219, 791);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGenerate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGenerate.Size = new System.Drawing.Size(143, 36);
            this.btnGenerate.TabIndex = 16;
            this.btnGenerate.Text = "Сгенерировать";
            this.btnGenerate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGenerate.UseAccentColor = false;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCheck.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCheck.Depth = 0;
            this.btnCheck.HighEmphasis = true;
            this.btnCheck.Icon = null;
            this.btnCheck.Location = new System.Drawing.Point(370, 791);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCheck.Size = new System.Drawing.Size(107, 36);
            this.btnCheck.TabIndex = 17;
            this.btnCheck.Text = "Проверить";
            this.btnCheck.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCheck.UseAccentColor = false;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // listBoxDictionary
            // 
            this.listBoxDictionary.BackColor = System.Drawing.Color.White;
            this.listBoxDictionary.BorderColor = System.Drawing.Color.LightGray;
            this.listBoxDictionary.Depth = 0;
            this.listBoxDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBoxDictionary.Location = new System.Drawing.Point(701, 541);
            this.listBoxDictionary.MouseState = MaterialSkin.MouseState.HOVER;
            this.listBoxDictionary.Name = "listBoxDictionary";
            this.listBoxDictionary.SelectedIndex = -1;
            this.listBoxDictionary.SelectedItem = null;
            this.listBoxDictionary.Size = new System.Drawing.Size(295, 241);
            this.listBoxDictionary.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 842);
            this.Controls.Add(this.listBoxDictionary);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnRemoveWord);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.txtClue);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.lstClues);
            this.Controls.Add(this.lblWordCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridCrossword);
            this.Name = "Form1";
            this.Text = "Crossword";
            ((System.ComponentModel.ISupportInitialize)(this.gridCrossword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCrossword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWordCount;
        private MaterialSkin.Controls.MaterialListBox lstClues;
        private MaterialSkin.Controls.MaterialTextBox2 txtWord;
        private MaterialSkin.Controls.MaterialTextBox2 txtClue;
        private MaterialSkin.Controls.MaterialButton btnAddWord;
        private MaterialSkin.Controls.MaterialButton btnRemoveWord;
        private MaterialSkin.Controls.MaterialButton btnGenerate;
        private MaterialSkin.Controls.MaterialButton btnCheck;
        private MaterialSkin.Controls.MaterialListBox listBoxDictionary;
    }
}

