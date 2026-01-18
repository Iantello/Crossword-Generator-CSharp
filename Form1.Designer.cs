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
            this.lstClues.Size = new System.Drawing.Size(298, 654);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
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
    }
}

