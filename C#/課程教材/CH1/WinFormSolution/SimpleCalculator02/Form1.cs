namespace SimpleCalculator02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Call Calculate with true for addition
            Calculate(true);
        }

        private void Calculate(bool isAdd)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);     
            if (!isAdd)
            {
                y = -y; // Negate y for subtraction
            }
            label1.Text = (x + y).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Call Calculate with false for subtraction
            Calculate(false);
        }
    }
}
