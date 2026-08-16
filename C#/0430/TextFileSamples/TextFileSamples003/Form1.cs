namespace TextFileSamples003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class RestArea
        {
            public string RiverSide { get; set; }
            public string Location { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string AreaType { get; set; }
        }

        async private Task<List<RestArea>> CreatDataasync()
        {
            string fileName = "臺北市河濱休憩點OK.csv";
            if (File.Exists(fileName))
            {
                return await File.ReadLinesAsync(fileName)
                            .Skip(1)
                            .Select((x) => x.Split(','))
                            .Select((x) => new RestArea
                            {
                                RiverSide = x[0],
                                Location = x[1],
                                Latitude = double.Parse(x[2]),
                                Longitude = double.Parse(x[3]),
                                AreaType = x[4]
                            }).ToListAsync();
            }
            return null;
        }

        async private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await CreatDataasync();
        }
    }
}
