#region Delegate

//int Add(int a, int b)
//{
//    return a + b;
//}

//MyDelegate del = Add;
//int a = del(3, 4);
//del?.Invoke(3, 4);


//delegate int MyDelegate(int a, int b);





//MyDelegate<int, string> del = .....

//delegate T MyDelegate<T, K>(T a, K b);

#endregion


#region Intro


//void RenderPlus()
//{
//    for (int i = 0; i < 1000; i++)
//        Console.Write('+');
//}

//Thread t = new Thread(RenderPlus);
//t.Start();

//for (int i = 0; i < 1000; i++)
//    Console.Write('0');



//void Run()
//{
//    for (int i = 0; i < 5; i++)
//        Console.Write('0');
//}

//new Thread(Run).Start();
//Run();




// ============  ПотокоНЕбезобасный код 
//bool done = false;

//void Run()
//{
//    if (!done)
//    {
//        Console.WriteLine('*');
//        done = true;
//        Console.WriteLine("DONE");
//    }
//}

//new Thread(Run).Start();
//Run();




// ============  Потокобезобасный код
//object locker = new object();
//bool done = false;

//void Run()
//{
//    lock(locker)
//    {
//        if (!done)
//        {
//            Console.WriteLine('*');
//            done = true;
//            Console.WriteLine("DONE");
//        }
//    }
//}

//new Thread(Run).Start();
//Run();






//void Run()
//{
//    for (int i = 0; i < 1000; ++i)
//        Console.Write('*');
//    Console.WriteLine();
//}

//Console.WriteLine("Main start");
//Thread t = new Thread(Run);
//t.Start();

//// Thread.Sleep(1);
//t.Join();               // Блокируем текущий поток (ждём завершения потока t)

//Console.WriteLine("Main end");

#endregion


#region Create / Start

// ============ Простые способы ============
//void Run()
//{
//    Console.WriteLine("hello");
//}

//Thread t = new Thread(new ThreadStart(Run));
//t.Start();
//Run();




//Thread t = new Thread(() => Console.WriteLine("Vasia"));
//t.Start();




//string email = "vasia@mail.com";

//// Thread t = new Thread(new ThreadStart(() => Console.WriteLine($"EMAIL: {email}")));
//// >>> EQUALS <<<
//Thread t = new Thread(() => Console.WriteLine($"EMAIL: {email}"));
//t.Start();





//void Calc(int a, int b)
//{
//    Console.WriteLine($"RESULT = {a + b}");
//}

//int a = 30;
//int b = 4;

//--- Способ 1

//void RunCalc(object? obj)
//{
//    if (obj is Parameters p)
//        Calc(p.x, p.y);
//}

//Thread t = new Thread(RunCalc);
//t.Start(new Parameters() { x = a, y = b });

//class Parameters
//{
//    public int x;
//    public int y;
//}


//--- Способ 2
//Thread t = new Thread(() => Calc(a, b));
//t.Start();


#endregion


#region Practice_1
// Из отдельного потока вывести сообщение в консоль.
// Вывод конфигурируется: сообщение, цвет сообщения

//string output = "Hello from my App";
//ConsoleColor color = ConsoleColor.Green;

//void Render(string message, ConsoleColor color = ConsoleColor.Blue)
//{
//    Console.ForegroundColor = color;
//    Console.WriteLine(message);
//    Console.ResetColor();
//}

//Thread t = new Thread(() => Render(output, color));
//t.Start();





//for (int i = 0; i < 10; ++i)
//    new Thread(() => Console.WriteLine(i)).Start();

//for (int i = 0; i < 10; ++i)
//{
//    int n = i;
//    new Thread(() => Console.WriteLine(n)).Start();
//}


//int i;
//List <Thread> threads = new List<Thread>();

//for (i = 0; i < 10; ++i)
//    threads.Add(new Thread(() => Console.WriteLine(i)));

//threads.ForEach(t => t.Start());




//void Run()
//{
//    Console.WriteLine($"Message FROM {Thread.CurrentThread.Name}");
//}

//Thread.CurrentThread.Name = "main";

//Thread t = new Thread(Run)
//{
//    Name = "worker",
//};

//t.Start();
//Run();





//Thread t = new Thread(() =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("Hello from worker");
//});

//if (args.Length > 0)
//    t.IsBackground = true;

//t.Start();
//Console.WriteLine("Hello from main");

#endregion


#region Exceptions handling

// :-(
//void Run()
//{
//    throw new Exception("Test exception");
//}

//try
//{
//    new Thread(Run).Start();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}


// :-)
//void Run()
//{
//	try
//	{
//		throw new Exception("Test exception");
//	}
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//}

//new Thread(Run).Start();

#endregion


#region TPL (Task Parallel Library)
// Task, Task<T>, ValueTask, ValueTask<T>, Parallel ......

//void Run()
//{
//    Console.WriteLine("Vasia");
//}

//Task task = Task.Factory.StartNew(() => Run());
////
////
//task.Wait();        // BLOCKING




using System.Net;

string DownloadPageSrc(string url)
{
    using WebClient client = new WebClient();

	try
	{
		string content = client.DownloadString(url);
		return content;
	}
	catch (Exception ex)
	{
        Console.WriteLine($"ERROR: {ex.Message}");
	}

	return string.Empty;
}

string url = @"https://habr.com/ru/feed/";

// sync
//string content = DownloadPageSrc(url);
//Console.WriteLine(content);

// async
Task<string> t = Task.Factory.StartNew(() => DownloadPageSrc(url));
//
Console.WriteLine("test");
//
string content = t.Result;          // BLOCKING
									// Console.WriteLine(content);
using Stream fs = File.OpenWrite("page.html");
using StreamWriter sw = new StreamWriter(fs);
sw.WriteLine(content);



#endregion




