using BizDataLibrary.Repositories;
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
    public partial class QueryInventoryForm : Form
    {
        public QueryInventoryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var context = Program.CreateBizContext();
            var service = new Services.ProcurementService(new BizRepository(context));
            dataGridView1.DataSource = service.GetInventorySummary().ToList();
        }
    }
}
