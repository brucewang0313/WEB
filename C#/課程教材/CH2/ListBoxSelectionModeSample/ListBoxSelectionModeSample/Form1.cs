using System.Windows.Forms;

namespace ListBoxSelectionModeSample
{
    public partial class Form1 : Form
    {
        List<string> _list;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            SetListBoxes();
        }

        private void CreateList()
        {
            _list = new List<string>()
            {
                 "Dog", "Cat", "Monkey",
                 "Fly", "Donkey"

            };

        }

        private void SetListBoxes()
        {
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox2.SelectionMode = SelectionMode.MultiSimple;
            listBox3.SelectionMode = SelectionMode.None;
            listBox4.SelectionMode = SelectionMode.One;

            listBox1.DataSource = _list.ToList();
            listBox2.DataSource = _list.ToList();
            listBox3.DataSource = _list.ToList();
            listBox4.DataSource = _list.ToList();

        }
    }
}
