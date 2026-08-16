namespace SimpleCalculator02
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
            button2 = new Button();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(91, 273);
            label1.Name = "label1";
            label1.Size = new Size(31, 36);
            label1.TabIndex = 9;
            label1.Text = "0";
            // 
            // button2
            // 
            button2.Font = new Font("微軟正黑體", 14F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button2.Location = new Point(242, 150);
            button2.Name = "button2";
            button2.Size = new Size(96, 96);
            button2.TabIndex = 8;
            button2.Text = "減";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("微軟正黑體", 14F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button1.Location = new Point(118, 150);
            button1.Name = "button1";
            button1.Size = new Size(96, 96);
            button1.TabIndex = 7;
            button1.Text = "加";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(84, 94);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(298, 30);
            textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(84, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 30);
            textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 398);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button2;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
