//  async    await

// 1. async

// 2. returns
// Task
// void             // :-(((
// Task<T>
// ValueTask
// ValueTask<T>
// IAsyncEnumerator<T>
// IAsyncEnumerable<T>
// .....

// 3. await 

// 4. ...Async



//// sync method
//void Method()
//{
//    Console.WriteLine("Start");

//    Task t = new Task(() => Thread.Sleep(1000));
//    t.Start();

//    Console.WriteLine("ONE");

//    t.Wait();           // BLOCKING

//    Console.WriteLine("End");
//}

//Console.WriteLine("Main start");
//Method();
//Console.WriteLine("Main end");






// async method
//async Task Method()
//{
//    Console.WriteLine("Start");

//    Task t = new Task(() => Thread.Sleep(1000));
//    t.Start();

//    Console.WriteLine("ONE");

//    // t.Wait();           // BLOCKING
//    await t;

//    Console.WriteLine("End");
//}

//Console.WriteLine("Main start");
//_ = Method();
//Console.WriteLine("Main end");

//Console.ReadLine();




// CANCEL
//async Task DownloadAsync(string url, CancellationToken token)
//{
//    //
//    //
//    HttpClient client = new HttpClient();
//    string content = await client.GetStringAsync(url, token);
//    //
//    //
//    Console.WriteLine(content);
//}

//var cts = new CancellationTokenSource();
//var token = cts.Token;

//_ = DownloadAsync("https://habr.com/ru/feed/", token);

//// Thread.Sleep(200);
//// cts.Cancel();

//Console.WriteLine("Main END");

//Console.ReadLine();






// EXAMPLE 1


//async Task<string> FetchDataAsync(string url)
//{
//    using var httpClient = new HttpClient();

//	try
//	{
//		Task<string> responceTask = httpClient.GetStringAsync(url);

//		// return responceTask.Result;			// BLOCKING

//		//responceTask.Wait();					// BLOCKING
//		//return responceTask.Result;

//		return await responceTask;

//	}
//	catch (Exception ex)
//	{
//        Console.WriteLine($"Request error: {ex.Message}");
//	}

//	return "no_content";
//}

//string content = await FetchDataAsync("https://habr.com/ru/feed/");
//Console.WriteLine(content);





// EXAMPLE 2

async Task<string> FetchDataAsync(string url, CancellationToken token)
{
	using var httpClient = new HttpClient();

	try
	{
		Task<string> responceTask = httpClient.GetStringAsync(url, token);

		return await responceTask;
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Request error: {ex.Message}");
	}

	return "no_content";
}

async Task<Dictionary<string, string>> FetchMultipleDataAsync(IEnumerable<string> urls, CancellationToken token)
{
	var tasks = new Dictionary<string, Task<string>>();

	foreach(string url in urls)
	{
		tasks.Add(url, FetchDataAsync(url, token));
	}

	await Task.WhenAll(tasks.Values);

	return tasks.ToDictionary(
		pair => pair.Key,
		pair => pair.Value.Result
	);
}

var cts = new CancellationTokenSource();
try
{
    Dictionary<string, string> results = await FetchMultipleDataAsync(new[]
	{
        "https://habr.com/ru/companies/jetinfosystems/news/1047770/",
        "https://habr.com/ru/news/1047768/",
        "https://habr.com/ru/companies/orion_soft/news/1047762/"
    }, cts.Token);

	foreach(var result in results)
	{
        Console.WriteLine($"{result.Key}: {result.Value.Length}");

		string fileName = $"{Guid.NewGuid().ToString()}.html";

		using FileStream fs = File.OpenWrite(fileName);
		using StreamWriter sw = new StreamWriter(fs);

		await sw.WriteAsync(result.Value);
	}
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
}



