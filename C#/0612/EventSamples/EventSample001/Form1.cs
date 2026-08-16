namespace EventSample001
{
    public partial class Form1 : Form
    {
        private MyClass obj;
        public Form1()
        {
            InitializeComponent();
            obj = new MyClass();
            obj.XChanged += Obj_XChange;
        }
        private void Obj_XChange(object? sender, EventArgs e)
        {
            MessageBox.Show($"X的值改變了");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.X += 1;
        }
    }
}
