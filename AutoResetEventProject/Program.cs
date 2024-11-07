int x = 0;
//AutoResetEvent waitHandler = new AutoResetEvent(false);
AutoResetEvent waitHandler = new AutoResetEvent(true);
for (int i = 1; i < 6; i++)
{
    Thread thread = new Thread(Print);
    thread.Name = $"Поток:{i}";
    thread.Start();
}
void Print()
{
    // waitHandler.WaitOne();
    AutoResetEvent.WaitAll(new WaitHandle[] {waitHandler});
        //x = 1;
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
        }
    waitHandler.Set();
}
