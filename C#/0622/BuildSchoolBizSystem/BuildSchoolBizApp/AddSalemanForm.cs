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
    public partial class AddSalemanForm : Form
    {
        public AddSalemanForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("業務員姓名不可空白");
                return;
            }
            var viewModel = new SalesmanViewModel
            {
                Name = textBox1.Text.Trim()
            };
            using var context = Program.CreateBizContext();
            var service = new SalesmanService(new BizRepository(context));
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
