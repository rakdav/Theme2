using System.ComponentModel;
using System.Text;

var backgroundWorker = new BackgroundWorker();
backgroundWorker.WorkerReportsProgress = true;
backgroundWorker.WorkerSupportsCancellation = true;
backgroundWorker.DoWork += SimulateServiceCall!;
backgroundWorker.ProgressChanged += ProgressChanged!;
backgroundWorker.RunWorkerCompleted += RunWorkerCompleted!;
backgroundWorker.RunWorkerAsync();
Console.WriteLine("To Cancel Worker Thread Press C.");
while (backgroundWorker.IsBusy)
{
    if (Console.ReadKey(true).KeyChar == 'C')
    {
        backgroundWorker.CancelAsync();
    }
}
void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
    if (e.Error != null)
    {
        Console.WriteLine(e.Error.Message);
    }
    else
        Console.WriteLine($"Result from service call is {e.Result}");
}
void ProgressChanged(object sender, ProgressChangedEventArgs e)
{
    Console.WriteLine($"{e.ProgressPercentage}% completed");
}
void SimulateServiceCall(object sender, DoWorkEventArgs e)
{
    var worker = sender as BackgroundWorker;
    StringBuilder data = new StringBuilder();
    for (int i = 1; i <= 100; i++)
    {
        if (!worker.CancellationPending)
        {
            data.Append(i);
            worker.ReportProgress(i);
            Thread.Sleep(100);
        }
        else
        {
            worker.CancelAsync();
        }
    }
    e.Result = data;
}