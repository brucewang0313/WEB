namespace ListSample001
{
    public partial class Form1 : Form
    {
        private List<MyRectangle> _list;
        public Form1()
        {
            InitializeComponent();
            // 注意兩個方法的呼叫順序
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyRectangle item = (MyRectangle)comboBox1.SelectedItem;
            MessageBox.Show($" {item.Name} 的面積為: {item.GetArea()}");
        }
    }
}
