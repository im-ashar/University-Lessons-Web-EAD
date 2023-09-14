using System.Collections;

public class MyEventArgs
{
    public object Data { get; set; }
}
public delegate void MyEventHandler(object sender, MyEventArgs e);
public class StackPublisher : Stack
{
    public event MyEventHandler EventHandler;
    public override void Push(object? obj)
    {
        MyEventArgs objMyEventArgs = new MyEventArgs();
        objMyEventArgs.Data = obj;
        EventHandler(this, objMyEventArgs);
        base.Push(obj);
    }

    public override object? Pop()
    {
        MyEventArgs objMyEventArgs = new MyEventArgs();
        objMyEventArgs.Data = base.Peek();
        EventHandler(this, objMyEventArgs);
        return base.Pop();
    }
}

public class StackSubscriber
{
    public void PushListener(object? obj, MyEventArgs e)
    {
        Console.WriteLine($"Object Added {e.Data}");
    }
    public void PopListener(object? obj, MyEventArgs e)
    {
        Console.WriteLine($"Object Removed {e.Data}");
    }
}

public class Program
{
    public static void Main()
    {
        StackPublisher stackPublisher = new StackPublisher();
        StackSubscriber stackSubscriber = new StackSubscriber();
        stackPublisher.EventHandler += stackSubscriber.PushListener;
        stackPublisher.Push(6);
        stackPublisher.Push(9);
        stackPublisher.EventHandler -= stackSubscriber.PushListener;
        stackPublisher.EventHandler += stackSubscriber.PopListener;
        stackPublisher.Pop();
    }




}