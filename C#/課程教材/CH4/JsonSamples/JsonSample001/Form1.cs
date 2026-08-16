using System.Text.Json;
namespace JsonSample001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }
        async private void button1_Click(object sender, EventArgs e)
        {
           string uri= "https://quality.data.gov.tw/dq_download_json.php?nid=143897&md5_url=34e22a40ac67292f7727e7e45c47e4d9";
            HttpClient httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(uri);
            var result = JsonSerializer.Deserialize<List<Class1>>(json);
            dataGridView1.DataSource = result;
        }
    }
}
