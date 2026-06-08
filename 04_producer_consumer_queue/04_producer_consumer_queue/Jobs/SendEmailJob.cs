using PCQ.Contracts;

namespace _04_producer_consumer_queue.Jobs;

internal class SendEmailJob : IJob
{
    public Random random;
    public required string Email { get; set; }
    public SendEmailJob()
    {
        random = new Random();
    }
    public string Info => $"Email = {Email}";

    public void Execute()
    {
        Thread.Sleep(random.Next(50, 200));
        // Console.WriteLine($"Email to {Email} was sended...");  // FIXME: for debug
    }
}
