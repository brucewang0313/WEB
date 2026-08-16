
namespace TextFileSample003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        async private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await CreateData();
        }

        async private Task<List<RestArea>> CreateData()
        {
            string fileName = "臺北市河濱休憩點OK.csv";
            if (File.Exists(fileName))
            {
                return await File.ReadLinesAsync(fileName)
                            .Skip(1)
                            .Select((x) => x.Split(','))
                            .Select((x) => new RestArea
                            {
                                Riverside = x[0],
                                Location = x[1],
                                Latitude = double.Parse(x[2]),
                                Longitude = double.Parse(x[3]),
                                AreaType = x[4]
                            }).ToListAsync();
            }
            return null;
        }
    }
}
