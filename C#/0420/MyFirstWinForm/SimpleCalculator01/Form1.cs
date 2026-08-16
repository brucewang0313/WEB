namespace SimpleCalculator01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculate("Add");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            calculate("Sub");
        }

        private void calculate(string math)//可以用布林值更簡單
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            if (math=="Add")
            {
                label1.Text = (x + y).ToString();
            }
            else
            {
                label1.Text = (x - y).ToString();
            }
        }
    }
}
