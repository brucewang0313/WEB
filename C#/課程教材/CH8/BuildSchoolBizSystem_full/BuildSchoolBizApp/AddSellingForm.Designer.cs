namespace BuildSchoolBizApp
{
    partial class AddSellingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            numericUpDown2 = new NumericUpDown();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            listBox1 = new ListBox();
            label1 = new Label();
            label5 = new Label();
            listBox2 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(425, 294);
            button1.Name = "button1";
            button1.Size = new Size(244, 75);
            button1.TabIndex = 19;
            button1.Text = "新增";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 255);
            label4.Name = "label4";
            label4.Size = new Size(46, 23);
            label4.TabIndex = 18;
            label4.Text = "日期";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(61, 294);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 30);
            dateTimePicker1.TabIndex = 17;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(425, 184);
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(244, 30);
            numericUpDown2.TabIndex = 16;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(425, 158);
            label3.Name = "label3";
            label3.Size = new Size(46, 23);
            label3.TabIndex = 15;
            label3.Text = "單價";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(425, 62);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(244, 30);
            numericUpDown1.TabIndex = 14;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(425, 36);
            label2.Name = "label2";
            label2.Size = new Size(82, 23);
            label2.TabIndex = 13;
            label2.Text = "出貨數量";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(52, 72);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(309, 142);
            listBox1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 36);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 11;
            label1.Text = "貨品選擇";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(699, 36);
            label5.Name = "label5";
            label5.Size = new Size(82, 23);
            label5.TabIndex = 20;
            label5.Text = "銷售人員";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(699, 72);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(235, 142);
            listBox2.TabIndex = 21;
            // 
            // AddSellingForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 450);
            Controls.Add(listBox2);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(numericUpDown2);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "AddSellingForm";
            Text = "銷售資料";
            Load += AddSellingForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown2;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private ListBox listBox1;
        private Label label1;
        private Label label5;
        private ListBox listBox2;
    }
}