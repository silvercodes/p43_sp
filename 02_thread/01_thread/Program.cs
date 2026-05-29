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





void Calc(int a, int b)
{
    Console.WriteLine($"RESULT = {a + b}");
}

int a = 30;
int b = 4;

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
Thread t = new Thread(() => Calc(a, b));
t.Start();


#endregion


