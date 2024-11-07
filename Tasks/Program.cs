Task task1 = new Task(() => Console.WriteLine("Hello,Task 1"));
task1.Start();
//task1.RunSynchronously();
Console.WriteLine(task1.Id);
Console.WriteLine(task1.IsCompleted);
Console.WriteLine(task1.Status);
Console.WriteLine(task1.AsyncState);
Console.WriteLine(Task.CurrentId);
Console.WriteLine(task1.Exception);
Console.WriteLine(task1.IsCanceled);
Console.WriteLine(task1.IsFaulted);
Console.WriteLine(task1.IsCompletedSuccessfully);
task1.Wait();

Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Hello,Task 2"));
task2.Wait();

Task task3 = Task.Run(() => Console.WriteLine("Hello,Task 3"));
task3.Wait();
//вложенные задачи
var outer = Task.Factory.StartNew(
() =>
{
    Console.WriteLine("Outer task start");
    var inner = Task.Factory.StartNew(
        () =>
        {
            Console.WriteLine("Inner task start");
            Thread.Sleep(1000);
            Console.WriteLine("Inner task finish");
        },TaskCreationOptions.AttachedToParent);
}
);
outer.Wait();
Console.WriteLine("Outer task finish");
//Массив задач
Task[] tasks = new Task[3]
{
    new Task(()=>Console.WriteLine("First task")),
    new Task(()=>Console.WriteLine("Second task")),
    new Task(()=>Console.WriteLine("Third task")),
};
foreach (var item in tasks) item.Start();
Task.WaitAll(tasks);
//возвращение результатов из задачи
int x = 7, y = 9;
Task<int> sumTask = new Task<int>(()=>Sum(x,y));
sumTask.Start();
int result = sumTask.Result;
Console.WriteLine($"{x}+{y}={result}");
int Sum(int a, int b) => a + b;