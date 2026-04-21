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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lstClues = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.txtClue = new System.Windows.Forms.TextBox();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnRemoveWord = new System.Windows.Forms.Button();
            this.listBoxDictionary = new System.Windows.Forms.ListBox();
            this.lblWordCount = new System.Windows.Forms.Label();
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
            this.gridCrossword.Size = new System.Drawing.Size(680, 676);
            this.gridCrossword.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.Location = new System.Drawing.Point(367, 694);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(94, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Сгенерировать";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.AutoSize = true;
            this.btnCheck.Location = new System.Drawing.Point(467, 694);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Проверить";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lstClues
            // 
            this.lstClues.FormattingEnabled = true;
            this.lstClues.Location = new System.Drawing.Point(698, 38);
            this.lstClues.Name = "lstClues";
            this.lstClues.Size = new System.Drawing.Size(298, 355);
            this.lstClues.TabIndex = 3;
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
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(694, 398);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(298, 20);
            this.txtWord.TabIndex = 5;
            this.txtWord.Text = "Введите слово";
            // 
            // txtClue
            // 
            this.txtClue.Location = new System.Drawing.Point(695, 425);
            this.txtClue.Name = "txtClue";
            this.txtClue.Size = new System.Drawing.Size(297, 20);
            this.txtClue.TabIndex = 6;
            this.txtClue.Text = "Введите загадку";
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(769, 452);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(75, 23);
            this.btnAddWord.TabIndex = 7;
            this.btnAddWord.Text = "Добавить";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnRemoveWord
            // 
            this.btnRemoveWord.Location = new System.Drawing.Point(851, 451);
            this.btnRemoveWord.Name = "btnRemoveWord";
            this.btnRemoveWord.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveWord.TabIndex = 8;
            this.btnRemoveWord.Text = "Удалить";
            this.btnRemoveWord.UseVisualStyleBackColor = true;
            this.btnRemoveWord.Click += new System.EventHandler(this.btnRemoveWord_Click);
            // 
            // listBoxDictionary
            // 
            this.listBoxDictionary.FormattingEnabled = true;
            this.listBoxDictionary.Location = new System.Drawing.Point(698, 515);
            this.listBoxDictionary.Name = "listBoxDictionary";
            this.listBoxDictionary.Size = new System.Drawing.Size(294, 173);
            this.listBoxDictionary.TabIndex = 9;
            // 
            // lblWordCount
            // 
            this.lblWordCount.AutoSize = true;
            this.lblWordCount.Location = new System.Drawing.Point(698, 496);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(35, 13);
            this.lblWordCount.TabIndex = 10;
            this.lblWordCount.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.lblWordCount);
            this.Controls.Add(this.listBoxDictionary);
            this.Controls.Add(this.btnRemoveWord);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.txtClue);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstClues);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.gridCrossword);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridCrossword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCrossword;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ListBox lstClues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.TextBox txtClue;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnRemoveWord;
        private System.Windows.Forms.ListBox listBoxDictionary;
        private System.Windows.Forms.Label lblWordCount;
    }
}

