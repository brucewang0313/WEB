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
    public partial class AddProcurementForm : Form
    {
        public AddProcurementForm()
        {
            InitializeComponent();
        }

        private void AddProcurementForm_Load(object sender, EventArgs e)
        {
            using var context = Program.CreateBizContext();
            var service = new ProductService(new BizRepository(context));
            var products = service.GetAll().ToList();
            listBox1.DataSource = products;
            listBox1.DisplayMember = "DisplayName";
            listBox1.ValueMember = "PartNo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇商品");
                return;
            }
            var viewModel = new ProcurementViewModel
            {
                PartNo = (string)listBox1.SelectedValue!,
                PurchasingDay = dateTimePicker1.Value,
                Quantity = (int)numericUpDown1.Value,
                InvetoryQuantity = (int)numericUpDown1.Value,
                UintPrice = (int)numericUpDown2.Value
            };
            using var context = Program.CreateBizContext();
            var service = new ProcurementService(new BizRepository(context));
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
