namespace BuildSchoolBizApp
{
    partial class QuerySellingBySalesForm
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
            listBox1 = new ListBox();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(27, 63);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(235, 142);
            listBox1.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 27);
            label5.Name = "label5";
            label5.Size = new Size(82, 23);
            label5.TabIndex = 22;
            label5.Text = "銷售人員";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(315, 27);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 24;
            label1.Text = "出貨日期";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(315, 80);
            label2.Name = "label2";
            label2.Size = new Size(54, 23);
            label2.TabIndex = 25;
            label2.Text = "From";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(315, 131);
            label3.Name = "label3";
            label3.Size = new Size(31, 23);
            label3.TabIndex = 26;
            label3.Text = "To";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(375, 74);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(231, 30);
            dateTimePicker1.TabIndex = 27;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(375, 131);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(231, 30);
            dateTimePicker2.TabIndex = 28;
            // 
            // button1
            // 
            button1.Location = new Point(654, 80);
            button1.Name = "button1";
            button1.Size = new Size(244, 75);
            button1.TabIndex = 29;
            button1.Text = "查詢";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 273);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(935, 298);
            dataGridView1.TabIndex = 30;
            // 
            // QuerySellingBySalesForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 571);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(label5);
            Name = "QuerySellingBySalesForm";
            Text = "查詢銷售人員出貨";
            Load += QuerySellingBySalesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button button1;
        private DataGridView dataGridView1;
    }
}