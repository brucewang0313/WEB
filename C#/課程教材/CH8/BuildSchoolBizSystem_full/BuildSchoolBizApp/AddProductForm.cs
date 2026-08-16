using BizDataLibrary.Repositories;
using BuildSchoolBizApp.Services;
using BuildSchoolBizApp.ViewModels;

namespace BuildSchoolBizApp
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //我是因為投影片放不下才切兩行的，你可以不用這麼做
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("料號或名稱不可為空白");
            }
            else
            {
                var viewModel = new ProductViewModel
                {
                    PartNo = textBox1.Text.Trim(),
                    PartName = textBox2.Text.Trim()
                };
                using var context = Program.CreateBizContext();
                var service = new ProductService(new BizRepository(context));
                var result = service.Create(viewModel);
                if (result.IsSuccessful)
                {
                    MessageBox.Show("新增成功");
                }
                else
                {
                    var path = result.WriteLog();
                    MessageBox.Show($"新增失敗 請參考 {path}");
                }

            }
        }
    }
}
