// Инструменты синхронизации

// 1. Простые методы блокировки
//      Thread.Sleep(), Thread.Join(), Task.Wait()......

// 2. Контроль критических секций
//      lock, Monitor(20нс), Mutex(1000нс), SpinLock, Semaphore(1000мс), SemaphoreSlim......

// 3. Инструменты сигнализации
//      Monitor.Pulse(), Monitor.PulseAll(), AutoResetEvent, ManualResetEvent, ContdownResetEvent.....

// 4. Неблокирующие инструменты
//      Thread.MemoryBarrier, Interlocked, Thread.VolatileRead......


// Причины разблокировки
// 1. Выполнено условие блокировки
// 2. Истёк таймаут
// 3. Thread.Interrupt()
// 4. Thread.Abort()

#region Блокировка lock / Monitor (ЭКСКЛЮЗИВНАЯ БЛОКИРОВКА)

//new Thread(ThreadUnsafe.Run).Start();
//ThreadUnsafe.Run();

//class ThreadUnsafe
//{
//    static int a = 10;
//    static int b = 20;

//    public static void Run()
//    {
//        int c = 0;

//        if (b != 0)
//        {
//            c = a / b;
//        }

//        b = 0;
//    }

//}



//new Thread(ThreadSafe.Run).Start();
//ThreadSafe.Run();
//class ThreadSafe
//{
//    static int a = 10;
//    static int b = 20;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;

//        // FIFO (Queue)
//        lock(locker)
//        {
//            if (b != 0)
//            {
//                c = a / b;
//            }

//            b = 0;
//        }
//    }
//}





//new Thread(ThreadSafe.Run).Start();
//ThreadSafe.Run();
//class ThreadSafe
//{
//    static int a = 10;
//    static int b = 20;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;
//        bool flag = false;

//        try
//        {
//            // FIFO
//            Monitor.Enter(locker, ref flag);    // Попытка взять блокировку у locker

//            if (b != 0)
//            {
//                c = a / b;
//            }

//            b = 0;
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"ERROR: {ex.Message}");
//        }
//        finally
//        {
//            if (flag)
//                Monitor.Exit(locker);           // Освобождение блокировки
//        }


//    }
//}







//object locker = new object();
//int val = 0;

//void Run()
//{
//    bool flag = false;

//    try
//    {
//        flag = Monitor.TryEnter(locker, 500);

//        if (flag)
//        {
//            for (int i = 0; i < 10; ++i)
//            {
//                Console.WriteLine($"{Thread.CurrentThread.Name}: {val++}");
//                Thread.Sleep(200);
//            }
//        }
//        else
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name} LOOSER!!!");
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//    finally
//    {
//        if (flag)
//            Monitor.Exit(locker);           // Освобождение блокировки
//    }
//}

//for (int i = 0; i < 5; ++i)
//{
//    Thread t = new Thread(Run)
//    {
//        Name = $"THREAD_{i}",
//    };
//    t.Start();
//}


#endregion


#region Mutex (ЭКСКЛЮЗИВНАЯ БЛОКИРОВКА)

//int count = 0;
//Mutex mutex = new Mutex();

//void UseResource()
//{
//    if (mutex.WaitOne(500))             // Попытка взять блокировку
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} take the mutex");

//        Thread.Sleep(200);
//        count++;

//        Console.WriteLine($"{Thread.CurrentThread.Name} done");
//        Console.WriteLine($"{Thread.CurrentThread.Name} release the mutex");

//        mutex.ReleaseMutex();
//    }
//    else
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} LOOSER!!!");
//    }
//}

//for (int i = 0; i < 5; ++i)
//{
//    Thread t = new Thread(UseResource)
//    {
//        Name = $"THREAD_{i}",
//    };
//    t.Start();
//}

#endregion


#region Semaphore (НЕ ЭКСКЛЮЗИВНАЯ БЛОКИРОВКА)

//Semaphore semaphre = new Semaphore(0, 3);
//object locker = new object();
//int executionTime = 0;

//void Run(int id)
//{
//    Console.WriteLine($"Thread_{id} started");

//    semaphre.WaitOne();             // Попытка взять блокировку

//    Console.WriteLine($"Thread_{id} passed semaphore");

//    int time;
//    lock(locker)
//    {
//        executionTime += 200;
//        time = executionTime;
//    }

//    Thread.Sleep(time + 2000);

//    Console.WriteLine($"Thread_{id} released semaphore");
//    semaphre.Release();             // Освободить 1 место
//}

//for (int i = 1; i <= 5; ++i)
//{
//    int x = i;
//    Thread t = new Thread(() => Run(x));
//    t.Start();
//}


//Thread.Sleep(3000);
//semaphre.Release(3);                // Освободить 3 места

#endregion


#region Signaling

object locker = new object();
void First()
{
	try
	{
		Monitor.Enter(locker);

		for(int i = 1; i <= 10; i += 2)
		{
			Thread.Sleep(200);
            Console.Write($"{i} ");

			Monitor.Pulse(locker);          // Перевод locker в сигнальное состояние (отдача блокировки)
			Monitor.Wait(locker);			// Блокировка следующего сигнального состояния
		}
	}
	finally
	{
		Monitor.Exit(locker);
	}
}

void Second()
{
    try
    {
        Monitor.Enter(locker);

        for (int i = 0; i <= 10; i += 2)
        {
            Thread.Sleep(200);
            Console.Write($"{i} ");

            Monitor.Pulse(locker);          // Перевод locker в сигнальное состояние (отдача блокировки)
            Monitor.Wait(locker);           // Блокировка следующего сигнального состояния
        }
    }
    finally
    {
        Monitor.Exit(locker);
    }
}

Thread t1 = new Thread(First);
Thread t2 = new Thread(Second);

t2.Start();
Thread.Sleep(3000);
t1.Start();


#endregion


