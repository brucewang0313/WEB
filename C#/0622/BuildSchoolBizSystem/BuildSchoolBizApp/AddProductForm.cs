using BizDataLibrary.Repositories;
using BuildSchoolBizApp.Services;
using BuildSchoolBizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            if(string.IsNullOrWhiteSpace(textBox1.Text)|| string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("料號或名稱不可空白");
            }
            else
            {
                var viewModel = new ProductViewModel
                {
                    PartNo = textBox1.Text,
                    PartName = textBox2.Text
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
                    MessageBox.Show($"新增失敗 請參考{path}");
                }
            }
        }
    }
}
