namespace DictionarySample001
{
    public partial class Form1 : Form
    {
        private Dictionary<string, MyRectangle> _dictionary;

        public Form1()
        {
            InitializeComponent();
            CreateDictionary();
        }
        private void CreateDictionary()
        {
            _dictionary = new Dictionary<string, MyRectangle>();
            _dictionary.Add("D1", new MyRectangle { Width = 5, Height = 5 });
            _dictionary.Add("D2", new MyRectangle { Width = 10, Height = 10 });
            _dictionary.Add("D3", new MyRectangle { Width = 20, Height = 20 });
            _dictionary.Add("D4", new MyRectangle { Width = 100, Height = 100 });
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string key = textBox1.Text;
            //if (_dictionary.ContainsKey(key))會寫成下面這種寫法(要優先選擇用：試試看寫法Try)
            if (_dictionary.TryGetValue(key, out MyRectangle rect))//傳出型參數為了回傳很多值
            {
                int area = rect.GetArea();
                MessageBox.Show($"{key}的面積為：{area}");
            }
            else
            {
                MessageBox.Show("查無資料：）");
            }
        }
    }
}
