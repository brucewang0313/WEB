namespace ListBoxSelectionModeSample
{
    partial class Form1
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
            label1 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label2 = new Label();
            listBox3 = new ListBox();
            label3 = new Label();
            listBox4 = new ListBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(91, 83);
            label1.Name = "label1";
            label1.Size = new Size(162, 28);
            label1.TabIndex = 0;
            label1.Text = "MultiExtended";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(91, 128);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(239, 349);
            listBox1.TabIndex = 1;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(393, 128);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(239, 349);
            listBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(393, 83);
            label2.Name = "label2";
            label2.Size = new Size(137, 28);
            label2.TabIndex = 2;
            label2.Text = "MultiSimple";
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(692, 128);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(239, 349);
            listBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(692, 83);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 4;
            label3.Text = "None";
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.Location = new Point(968, 128);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(239, 349);
            listBox4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label4.Location = new Point(968, 83);
            label4.Name = "label4";
            label4.Size = new Size(55, 28);
            label4.TabIndex = 6;
            label4.Text = "One";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 557);
            Controls.Add(listBox4);
            Controls.Add(label4);
            Controls.Add(listBox3);
            Controls.Add(label3);
            Controls.Add(listBox2);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label2;
        private ListBox listBox3;
        private Label label3;
        private ListBox listBox4;
        private Label label4;
    }
}
