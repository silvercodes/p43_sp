
#region Постановка Task в очередь в ThreadPool (запуск/вызов)

//Task t1 = new Task(() => Console.WriteLine("Vasia"));
//t1.Start();

//Task t2 = Task.Factory.StartNew(() => Console.WriteLine("Petya"));

//Task t3 = Task.Run(() => Console.WriteLine("Dima"));


//t1.Wait();
//t2.Wait();
//t3.Wait();

#endregion


#region Run synchronously

//Task t = new Task(() =>
//{
//    Console.WriteLine("Start");
//    Thread.Sleep(3000);
//    Console.WriteLine("End");
//});

//// t.Start();                  // async call
//t.RunSynchronously();       // sync call

//Console.WriteLine("from Main");
//Console.ReadLine();

#endregion


#region Task info

//Task t = new Task(() =>
//{
//    // Console.WriteLine("Start");
//    Thread.Sleep(3000);
//    Console.WriteLine("End");
//});
//t.Start();

//Console.WriteLine(t.Id);
//Console.WriteLine(t.Status);
//Console.WriteLine(t.IsCompleted);
//Console.WriteLine(t.Exception);

#endregion


#region Imbedded Tasks

//Task t1 = new Task(() =>
//{
//    Console.WriteLine("t1 started");

//    Task t2 = new Task(() =>
//    {
//        Console.WriteLine("t2 started");
//        Thread.Sleep(1000);
//        Console.WriteLine("t2 finished");
//    }, TaskCreationOptions.AttachedToParent);
//    t2.Start();

//    Console.WriteLine("t1 finished");
//});

//t1.Start();
//t1.Wait();

//Console.WriteLine("Main finished");

#endregion


#region Task collection

//long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//List<Task> tasks = new List<Task>()
//{
//    new Task(() =>
//    {
//        Thread.Sleep(1000);
//        Console.WriteLine("Task 1000 ms finished");
//    }),
//    new Task(() =>
//    {
//        Thread.Sleep(1200);
//        Console.WriteLine("Task 1200 ms finished");
//    }),
//    new Task(() =>
//    {
//        Thread.Sleep(2000);
//        Console.WriteLine("Task 2000 ms finished");
//    }),
//};

//tasks.ForEach(t => t.Start());

//// Task.WaitAll(tasks);                 // BLOCKING
//Task.WaitAny(tasks.ToArray());          // BLOCKING

//Console.WriteLine($"Time = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time}");


//Console.WriteLine("Main finished");

#endregion


#region Returns value from Task

//Task<int> t = new Task<int>(() =>
//{
//    Thread.Sleep(1000);
//    return 10;
//});
//t.Start();
////
////
//int result = t.Result;          // BLOCKING
//Console.WriteLine($"result = {result}");




//Task<Thread> t = new Task<Thread>(() =>
//{
//    Thread thread = new Thread(() => Console.WriteLine("test from thread"));
//    Thread.Sleep(3000);

//    return thread;
//});
//t.Start();
////
////
////
//Thread thread = t.Result;           // BLOCKING
//thread.Start();

#endregion


#region Tasks chain
using System.Text;

//// ---- :-(
//Photo photo = new Photo();

//Task<Photo> t = new Task<Photo>(() =>
//{
//    Task<Photo> t1 = new Task<Photo>(() =>
//    {
//        Thread.Sleep(1000);
//        photo.Filters.Add("filter_1");

//        return photo;
//    });

//    t1.Start();
//    Photo result1 = t1.Result;

//    Task<Photo> t2 = new Task<Photo>(() =>
//    {
//        Thread.Sleep(1000);
//        photo.Filters.Add("filter_2");

//        return photo;
//    });

//    t2.Start();
//    Photo result2 = t2.Result;

//    Task<Photo> t3 = new Task<Photo>(() =>
//    {
//        Thread.Sleep(1000);
//        photo.Filters.Add("filter_3");

//        return photo;
//    });

//    t3.Start();
//    Photo result3 = t3.Result;

//    return result3;
//});
//t.Start();
////
////
////
//Photo result = t.Result;
//Console.WriteLine(result);


// ---- :-)

//Photo photo = new Photo();

//Task<Photo> t1 = new Task<Photo>(() =>
//{
//    Thread.Sleep(1000);
//    photo.Filters.Add("filter_1");

//    return photo;
//});

//Task<Photo> taskResult = t1.ContinueWith((t) =>
//{
//    Photo res = t.Result;
//    Thread.Sleep(1000);
//    res.Filters.Add("filter_2");

//    return res;
//}).ContinueWith((t) =>
//{
//    Photo res = t.Result;
//    Thread.Sleep(1000);
//    res.Filters.Add("filter_3");

//    return res;
//});

//t1.Start();
////
////
//Photo result = taskResult.Result;       // BLOCKING
//Console.WriteLine(result);




//class Photo
//{
//    public List<string> Filters { get; set; } = new List<string>();
//    public override string ToString()
//    {
//        StringBuilder sb = new StringBuilder();
//        Filters.ForEach(f => sb.Append($"{f} "));

//        return sb.ToString();
//    }
//}




//Task t1 = new Task(() => Console.WriteLine("first task"));

//Task chain = t1
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id));

//t1.Start();
//chain.Wait();


#endregion


#region Parallel

Parallel.Invoke(
    TestPrint,
    () => Console.WriteLine("test lambda"),
    () => Sum(3, 4)
);




void TestPrint()
{
    Thread.Sleep(2000);
    Console.WriteLine("testp print");
}

int Sum(int a, int b) => a + b;



#endregion

