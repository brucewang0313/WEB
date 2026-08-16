namespace ListSample002
{
    public partial class Form1 : Form
    {
        private List<MyRectangle> _list;

        public Form1()
        {
            InitializeComponent();
            CreateList();
            SetComboBox();
        }
        private void CreateList()
        {
            _list = new List<MyRectangle>()//寫法不同要注意用逗號分隔
            {
                new MyRectangle { Name = "D1", Width = 5, Height = 5 },
                new MyRectangle { Name = "D2", Width = 10, Height = 10 },
                new MyRectangle { Name = "D3", Width = 20, Height = 20 },
                new MyRectangle { Name = "D4", Width = 100, Height = 100 }
            };
        }
        private void SetComboBox()
        {
            comboBox1.DataSource = _list;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Area";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int area = (int)comboBox1.SelectedValue;//比較SelectItem取得的是物件，這邊的int是實質型別
            MessageBox.Show($"面積為: {area}");
        }
    }
}
