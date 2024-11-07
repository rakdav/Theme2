//класс Thread
//класс ThreadPool
//класс Backgroungworker
//асинхронные делегаты
//TPL
Console.WriteLine("Основной поток: ставим в очередь рабочий элемент");
Random r = new Random();
for (int i = 0; i < 10; ++i)
    ThreadPool.QueueUserWorkItem(WorkingElementMethod!, r.Next(10));
Console.WriteLine("Основной поток: выполняем другие задачи");
Thread.Sleep(1000);
Console.WriteLine("Нажмите любую клавишу для продолжения...");
void WorkingElementMethod(object state)
{
    Console.WriteLine($"Поток:{Thread.CurrentThread.ManagedThreadId}," +
        $" coстояние:{state}");
    Thread.Sleep(1000);
}