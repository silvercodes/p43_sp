using _04_producer_consumer_queue.Jobs;
using PCQ;

QueueManager qm = new QueueManager(1000);

for (int i = 0; i < 1000; ++i)
{
    qm.EnqueueJob(new SendEmailJob() { Email = $"user_{i}@mail.com" });
}

for (int i = 0; i < 200; ++i)
{
    Thread.Sleep(100);
    Console.WriteLine($"Main: {i}");
}
