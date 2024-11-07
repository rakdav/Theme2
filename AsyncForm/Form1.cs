namespace AsyncForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintName("sync1");
            PrintName("sync2");
            PrintName("sync3");
        }
        private void PrintName(string name)
        {
            Thread.Sleep(3000);
        }
        private async Task PrintNameAsync(string name)
        {
            await Task.Delay(3000);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await PrintNameAsync("async1");
            await PrintNameAsync("async2");
            await PrintNameAsync("async3");
        }
    }
}
