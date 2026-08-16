using EntitySample001.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EntitySample001
{
    public partial class Viewform : Form
    {
        public Viewform()
        {
            InitializeComponent();
            BindData();
        }
        private void BindData()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContactContext>();
            optionsBuilder.UseSqlServer(Program.Configuration?.GetConnectionString("DefaultConnection"));
            using (var context = new ContactContext(optionsBuilder.Options))
            {
                var data = context.ContactsTables.ToList();
                dataGridView1.DataSource = data;
            }
        }
    }
}
