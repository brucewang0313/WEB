using InterfaceSample002.InterfaceSample002;

namespace InterfaceSample002
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeopleFactory factory = new PeopleFactory();
            dataGridView1.DataSource = factory.GetPeopleList(SourceType.CSV);
        }
    }
}
