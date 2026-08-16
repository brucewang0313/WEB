namespace ListSample005
{
    public partial class Form1 : Form
    {
        private List<string> _leftList;
        private List<string> _rightList;
        public Form1()
        {
            InitializeComponent();
            CreatList();
            SetSelectionMode();
            ChangeData();
        }
        private void CreatList()
        {
            _leftList = new List<string>
            {
                "A","B","C","D"
            };
            _rightList = new List<string>();
        }
        private void SetSelectionMode()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
        }
        private void ChangeData()
        {
            listBox1.DataSource = null;//為了讓ListBox知道改變了才讓他先指向null，在指回來。
            listBox2.DataSource = null;//若沒有null的話ListBox不會改變。
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string item = (string)listBox1.SelectedItem;
                _leftList.Remove(item);
                _rightList.Add(item);
                ChangeData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string item = (string)listBox2.SelectedItem;
                _rightList.Remove(item);
                _leftList.Add(item);
                ChangeData();
            }
        }
    }
}
