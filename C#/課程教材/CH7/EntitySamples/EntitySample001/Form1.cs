namespace EntitySample001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form= new ViewForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            form.ShowDialog();
        }
    }
}
