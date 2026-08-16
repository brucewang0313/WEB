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

            // 各種不同新增資料到 Dictionary 的方式  

            // (1) 集合初始設定式 (Collection Initializers) + 物件初始設定式 (Object Initializers)
            //_dictionary = new Dictionary<string, MyRectangle>
            //{
            //    {"D1" ,new MyRectangle { Width =5, Height=5 }},
            //    {"D2", new MyRectangle { Width = 10, Height = 10 }},
            //    {"D3", new MyRectangle { Width = 20, Height = 20 }},
            //    {"D4", new MyRectangle { Width = 100, Height = 100 }}
            //};

            // (2) 直接指派資料 + 物件初始設定式 (Object Initializers)
            //_dictionary["D5"] = new MyRectangle { Width = 9, Height = 8 }; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = textBox1.Text;

            // 透過 ContainsKey 方法來判斷是否有此 Key
            if (_dictionary.ContainsKey(key))
            {
                int area = _dictionary[key].GetArea();
                MessageBox.Show($"{key} 的面積為： {area}");
            }
            else
            {
                MessageBox.Show("查無資料");
            }

            // 或是使用 TryGetValue 方法 (參考 https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic.dictionary-2.trygetvalue?view=net-9.0)
            // 一般推薦使用這一種，效能上略優
            //if (_dictionary.TryGetValue(key, out MyRectangle rect))
            //{
            //    int area = rect.GetArea();
            //    MessageBox.Show($"{key} 的面積為： {area}");
            //}
            //else
            //{
            //    MessageBox.Show("查無資料");
            //}
        }
    }
}
