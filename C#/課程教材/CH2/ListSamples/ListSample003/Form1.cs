namespace ListSample003
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
            _list = new List<MyRectangle>()
            {
                new MyRectangle { Name = "D1", Width = 5, Height = 5 },
                new MyRectangle { Name = "D2", Width = 10, Height = 10 },
                new MyRectangle { Name = "D3", Width = 20, Height = 20 },
                new MyRectangle { Name = "D4", Width = 100, Height = 100 }
            };
        }
        private void SetComboBox()
        {
            // Selected Index = -1           
            comboBox1.DataSource = _list;
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            // 來點變化，從參數中取得觸發該事件的物件
            ComboBox theComboBox = (ComboBox)sender;
            int index = theComboBox.SelectedIndex;
            MyRectangle item = _list[index];
            MessageBox.Show($"取得索引 {index} 的面積為: {item.Area}");
        }
    }
}
