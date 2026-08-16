namespace SimpleCalculator03
{
    public partial class Form1 : Form
    {
        private Calculator _calculator;
        public Form1()
        {
            InitializeComponent();
            _calculator = new Calculator();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = CallCalculstor("+");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = CallCalculstor("-");
        }
        private string CallCalculstor(string operation)
        {
            _calculator.X = int.Parse(textBox1.Text);
            _calculator.Y = int.Parse(textBox2.Text);
            switch (operation)
            {
                case "+":
                    return _calculator.Add().ToString();
                case "-":
                    return _calculator.Subtract().ToString();
                default:
                    return "Unknown operation";
            }

        }
    }
}
