namespace CakeSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 我有一個模具
            雞蛋糕模具.把手 = "木頭材質";
            雞蛋糕模具.上鐵板 = "304 不鏽鋼";
            雞蛋糕模具.下鐵板 = "304 不鏽鋼";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 老闆我要一個雞蛋糕
            雞蛋糕模具 雞蛋糕 = new 雞蛋糕模具();
            // 這個雞蛋糕的內餡是奶油的
            雞蛋糕.內餡 = "奶油";

            MessageBox.Show($"你吃了一個內餡是 {雞蛋糕.內餡} 的雞蛋糕");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 老闆，你的模具的把手是甚麼做的？
            MessageBox.Show($"老闆曰 : 把手是 {雞蛋糕模具.把手}");

            // 老闆，你的模具的上鐵板是甚麼材質
            MessageBox.Show($"老闆曰 : 上鐵板是 {雞蛋糕模具.上鐵板}");
        }
    }
}
