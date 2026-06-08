namespace PCQ.Contracts;

public interface IJob
{
    public string Info { get; }         // FIXME: for debug
    public void Execute();
}
