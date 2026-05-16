
#region Process

// 1. Memory scope

// 2. Исполняемый код

// 3. Сиситемные дискрипторы

// 4. Констекст безопасности

// 5. Идентификатор

// 6. Переменные окружения

// 7. Приоритет

// 8. Поток выполнения (как минимум 1)



using System.Diagnostics;

//Process[] processes = Process.GetProcesses();
//IEnumerable<Process> proc = processes.OrderBy(p => p.Id);

//foreach (Process p in proc)
//    Console.WriteLine($"id: {p.Id} {p.ProcessName}");





//Console.Write("Enter PID: ");
//string? input = Console.ReadLine();

//try
//{
//    int pid = int.Parse(input);

//    Process p = Process.GetProcessById(pid);

//    var threads = p.Threads;
//    Console.WriteLine("Thread list:");
//    foreach (ProcessThread t in threads)
//        Console.WriteLine($"{t.Id}\t{t.StartTime.ToShortTimeString()}\t{t.PriorityLevel}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}




// Process.Start("notepad");

// Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "https://wikipedia.org --incognito");

Console.WriteLine("Hello from .NET project");

Process.Start(@"C:\Users\ThinkPad\Desktop\111_test.exe");




#endregion








