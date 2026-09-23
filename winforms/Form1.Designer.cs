namespace winforms
{
    partial class formandq
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formandq));
            StabilityLabel = new Label();
            SData = new DataGridView();
            Add = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)SData).BeginInit();
            SuspendLayout();
            // 
            // StabilityLabel
            // 
            StabilityLabel.AutoSize = true;
            StabilityLabel.Font = new Font("Wingdings", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 2);
            StabilityLabel.ForeColor = Color.Ivory;
            StabilityLabel.Location = new Point(361, 9);
            StabilityLabel.Name = "StabilityLabel";
            StabilityLabel.Size = new Size(135, 23);
            StabilityLabel.TabIndex = 0;
            StabilityLabel.Text = "label1";
            // 
            // SData
            // 
            SData.AllowUserToAddRows = false;
            SData.AllowUserToDeleteRows = false;
            SData.AllowUserToResizeColumns = false;
            SData.AllowUserToResizeRows = false;
            SData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SData.EditMode = DataGridViewEditMode.EditProgrammatically;
            SData.Location = new Point(100, 100);
            SData.Name = "SData";
            SData.ReadOnly = true;
            SData.RowHeadersVisible = false;
            SData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SData.Size = new Size(600, 300);
            SData.TabIndex = 1;
            // 
            // Add
            // 
            Add.Location = new Point(100, 478);
            Add.Name = "Add";
            Add.Size = new Size(100, 35);
            Add.TabIndex = 2;
            Add.Text = "Добавить";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // button2
            // 
            button2.Location = new Point(100, 528);
            button2.Name = "button2";
            button2.Size = new Size(100, 35);
            button2.TabIndex = 3;
            button2.Text = "Изменить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Edit_Click;
            // 
            // button3
            // 
            button3.Location = new Point(220, 478);
            button3.Name = "button3";
            button3.Size = new Size(100, 35);
            button3.TabIndex = 4;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Delete_Click;
            // 
            // button4
            // 
            button4.Location = new Point(220, 528);
            button4.Name = "button4";
            button4.Size = new Size(100, 35);
            button4.TabIndex = 5;
            button4.Text = "Обновить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Refresh_Click;
            // 
            // button5
            // 
            button5.ForeColor = Color.DarkRed;
            button5.Location = new Point(400, 478);
            button5.Name = "button5";
            button5.Size = new Size(180, 35);
            button5.TabIndex = 6;
            button5.Text = "Разлом";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Rift_Click;
            // 
            // button6
            // 
            button6.ForeColor = Color.DarkGreen;
            button6.Location = new Point(400, 528);
            button6.Name = "button6";
            button6.Size = new Size(180, 35);
            button6.TabIndex = 7;
            button6.Text = "Стабилизация";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Stabilization_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.ForeColor = Color.Black;
            button7.Location = new Point(650, 513);
            button7.Name = "button7";
            button7.Size = new Size(50, 50);
            button7.TabIndex = 8;
            button7.Text = "Выход";
            button7.UseVisualStyleBackColor = false;
            button7.Click += Exit_Click;
            // 
            // formandq
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 650);
            ControlBox = false;
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(Add);
            Controls.Add(SData);
            Controls.Add(StabilityLabel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "formandq";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)SData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label StabilityLabel;
        private DataGridView SData;
        private Button Add;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
