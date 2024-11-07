//async Task PrintAsync()
//{
//    await Task.Delay(3000);
//    Console.WriteLine("Start PrintTask");
//    await Task.Run(()=>Print());
//    Console.WriteLine("Finish printTask");
//}
//void Print()
//{
//    //Thread.Sleep(1000);
//    Console.WriteLine("Hello");
//}
//Console.WriteLine("Main thread start");
//await PrintAsync();
//Console.WriteLine("Main thread finish");
//void PrintName(string name)
//{
//    Thread.Sleep(3000);
//    Console.WriteLine(name);
//}
//async Task PrintNameAsync(string name)
//{
//    await Task.Delay(3000);
//    Console.WriteLine(name);
//}
//PrintName("sync1");
//Console.ReadKey();
//PrintName("sync2");
//PrintName("sync3");

//await PrintNameAsync("async1");
//await PrintNameAsync("async2");
//await PrintNameAsync("async3");

//void
//async void PrintAsync(string mes)
//{
//    await Task.Delay(1000);
//    Console.WriteLine($"{mes}, hello!");
//}
//PrintAsync("Masha");
//await Task.Delay(1000);

//Task

//async Task PrintAsync(string mes)
//{
//    await Task.Delay(0);
//    Console.WriteLine($"{mes}, hello!");
//}
//var task = PrintAsync("Arina");
//await task;

//Task<T>

//async Task<int> SquareAsync(int n)
//{
//    await Task.Delay(0);
//    return n * n;
//}

//int n1 = await SquareAsync(7);
//int n2 = await SquareAsync(9);
//Console.WriteLine(n1+" "+n2);

//ValueTask<T>
//ValueTask<int> AddAsync(int a,int b)
//{
//    return new ValueTask<int>(a + b);
//}
//Console.WriteLine(await AddAsync(5,9));

//Task.WhenAll и Task.WhenAny
//async Task PrintAsync(string mes)
//{
//    await Task.Delay(2000);
//    Console.WriteLine(mes);
//}
//var task1 = PrintAsync("Dы все в заложниках у Андрея Валентиновича");
//var task2 = PrintAsync("В натуре.");
//var task3 = PrintAsync("Это правда.");

//await Task.WhenAll(task1,task2,task3);

//await Task.WhenAny(task1,task2,task3);

async Task<int> SquareAsync(int n)
{
    if (n < 0) throw new ArgumentException($"Число {n} меньше нуля");
    await Task.Delay(1000);
    return n * n;
}
var task1 = SquareAsync(-6);
var task2 = SquareAsync(3);
var task3 = SquareAsync(7);
try
{
    int[] res = await Task.WhenAll(task1, task2, task3);

    foreach (int item in res)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine(task2.Result);

}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}