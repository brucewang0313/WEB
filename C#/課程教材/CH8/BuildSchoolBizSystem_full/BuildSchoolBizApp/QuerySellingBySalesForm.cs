using BizDataLibrary.Repositories;
using BuildSchoolBizApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildSchoolBizApp
{
    public partial class QuerySellingBySalesForm : Form
    {
        public QuerySellingBySalesForm()
        {
            InitializeComponent();
        }

        private void QuerySellingBySalesForm_Load(object sender, EventArgs e)
        {
            using var context = Program.CreateBizContext();
            BindSalesmanListBox(context);
        }

        private void BindSalesmanListBox(DbContext context)
        {
            var service = new SalesmanService(new BizRepository(context));
            var salesmen = service.GetAll().ToList();
            listBox1.DataSource = salesmen;
            listBox1.DisplayMember = "DisplayName";
            listBox1.ValueMember = "JobNumber";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇業務員");
                return;
            }
            int jobNumber = (int)listBox1.SelectedValue!;
            var begin = dateTimePicker1.Value.Date;
            var end = dateTimePicker2.Value.Date.AddDays(1);
            using var context = Program.CreateBizContext();
            var service = new SellingService(new BizRepository(context));
            var results = service.GetSellingBySalesAndDay(jobNumber, begin, end);
            dataGridView1.DataSource = results.ToList();
        }
    }
}
