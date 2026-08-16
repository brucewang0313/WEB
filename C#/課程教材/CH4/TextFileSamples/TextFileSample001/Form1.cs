namespace TextFileSample001
{
    public partial class Form1 : Form
    {
        private string filePath;
        public Form1()
        {
            InitializeComponent();
            filePath = "test.txt";
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (File.Exists(filePath))
            {
                textBox1.Text = await File.ReadAllTextAsync(filePath);
            }
            else
            {
                MessageBox.Show($"{filePath} 檔案不存在");
            }
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            await File.WriteAllTextAsync(filePath, textBox1.Text);
            MessageBox.Show($"已寫入 {filePath} 檔案");
        }
       
    }
}
