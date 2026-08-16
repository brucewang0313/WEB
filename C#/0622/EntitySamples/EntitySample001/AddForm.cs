using EntitySample001.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace EntitySample001
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContactsTable data = new ContactsTable()
            {
                UserName = textBox1.Text,
                Address = textBox2.Text,
                Phone = textBox3.Text
            };
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<ContactContext>();
                optionsBuilder.UseSqlServer(Program.Configuration?.GetConnectionString("DefaultConnection"));
                using (var context = new ContactContext(optionsBuilder.Options))
                {
                    context.ContactsTables.Add(data);
                    context.SaveChanges();
                }
                MessageBox.Show("新增成功");
                ClearTextBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show("新增失敗" + ex.Message);
            }
        }
        private void ClearTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
