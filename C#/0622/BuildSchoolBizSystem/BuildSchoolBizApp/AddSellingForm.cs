using BizDataLibrary.Repositories;
using BuildSchoolBizApp.Services;
using BuildSchoolBizApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BuildSchoolBizApp
{
    public partial class AddSellingForm : Form
    {
        public AddSellingForm()
        {
            InitializeComponent();
        }

        private void AddSellingForm_Load(object sender, EventArgs e)
        {
            using var context = Program.CreateBizContext();
            BindProductListBox(context);
            BindSalesmanListBox(context);
        }
        private void BindProductListBox(DbContext context)
        {
            var service = new ProductService(new BizRepository(context));
            var products = service.GetAll().ToList();
            listBox1.DataSource = products;
            listBox1.DisplayMember = "DisplayName";
            listBox1.ValueMember = "PartNo";
        }
        private void BindSalesmanListBox(DbContext context)
        {
            var service = new SalesmanService(new BizRepository(context));
            var salesmen = service.GetAll().ToList();
            listBox2.DataSource = salesmen;
            listBox2.DisplayMember = "DisplayName";
            listBox2.ValueMember = "JobNumber";
        }
        private static bool CanSell(string partNo, int quantity)
        {
            using var context = Program.CreateBizContext();
            var service = new ProcurementService(new BizRepository(context));
            var inventoryQuantity = service.GetInventoryQuantity(partNo);
            return inventoryQuantity >= quantity;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("起選擇商品");
                return;
            }
            if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("起選擇業務員");
                return;
            }
            var partNo = (string)listBox1.SelectedValue;
            var quantity = (int)numericUpDown1.Value;

            if (!CanSell(partNo, quantity))
            {
                MessageBox.Show("庫存不足，無法銷售");
            }
            var viewmodel = new SellingViewModel()
            {
                PartNo = partNo,
                Quantity = quantity,
                SalesJobNumber = (int)listBox2.SelectedValue!,
                SellingDay = dateTimePicker1.Value,
                UnitPrice = (int)numericUpDown2.Value,
            };
            using var context = Program.CreateBizContext();
            var service = new SellingService(new BizRepository(context));
            var result = service.Create(viewmodel);
            if (result.IsSuccessful)
            {
                MessageBox.Show("銷售成功 ");
            }
            else
            {
                var path = result.WriteLog();
                MessageBox.Show($"銷售失敗 請參考{path}");
            }
        }
    }
}
