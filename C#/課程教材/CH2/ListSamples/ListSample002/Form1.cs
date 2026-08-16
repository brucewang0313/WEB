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
            _list = new List<MyRectangle>();
            _list.Add(new MyRectangle { Name = "D1", Width = 5, Height = 5 });
            _list.Add(new MyRectangle { Name = "D2", Width = 10, Height = 10 });
            _list.Add(new MyRectangle { Name = "D3", Width = 20, Height = 20 });
            _list.Add(new MyRectangle { Name = "D4", Width = 100, Height = 100 });

            // 另一種方式
            //_list = new List<MyRectangle>()
            //{
            //    new MyRectangle { Name = "D1", Width = 5, Height = 5 },
            //    new MyRectangle { Name = "D2", Width = 10, Height = 10 },
            //    new MyRectangle { Name = "D3", Width = 20, Height = 20 },
            //    new MyRectangle { Name = "D4", Width = 100, Height = 100 }
            //};
        }

        private void SetComboBox()
        {
            comboBox1.DataSource = _list;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Area";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SelectedItem 取得的是物件 (依然是 MyRectangle)
            int area = (int)comboBox1.SelectedValue;
            MessageBox.Show($"面積為: {area}");
        }
    }
}
