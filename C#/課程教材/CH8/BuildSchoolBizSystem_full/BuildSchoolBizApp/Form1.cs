namespace BuildSchoolBizApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddSalesmanForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AddProcurementForm().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AddSellingForm().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new QuerySellingBySalesForm().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new QueryInventoryForm().ShowDialog();
        }
    }
}
