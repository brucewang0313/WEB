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
            label1 = new Label();
            listBox1 = new ListBox();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            listBox2 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 52);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 0;
            label1.Text = "貨品選擇";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(49, 78);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(248, 142);
            listBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 254);
            label2.Name = "label2";
            label2.Size = new Size(46, 23);
            label2.TabIndex = 2;
            label2.Text = "日期";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(51, 290);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(246, 30);
            dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(354, 52);
            label3.Name = "label3";
            label3.Size = new Size(82, 23);
            label3.TabIndex = 4;
            label3.Text = "出貨數量";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(354, 78);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(180, 30);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(354, 149);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(180, 30);
            numericUpDown2.TabIndex = 7;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(354, 123);
            label4.Name = "label4";
            label4.Size = new Size(46, 23);
            label4.TabIndex = 6;
            label4.Text = "單價";
            // 
            // button1
            // 
            button1.Location = new Point(354, 223);
            button1.Name = "button1";
            button1.Size = new Size(180, 84);
            button1.TabIndex = 8;
            button1.Text = "新增";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(554, 52);
            label5.Name = "label5";
            label5.Size = new Size(82, 23);
            label5.TabIndex = 9;
            label5.Text = "銷售人員";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(554, 78);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(213, 142);
            listBox2.TabIndex = 10;
            // 
            // AddSellingForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox2);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(numericUpDown2);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "AddSellingForm";
            Text = "AddSellingForm";
            Load += AddSellingForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label4;
        private Button button1;
        private Label label5;
        private ListBox listBox2;
    }
}