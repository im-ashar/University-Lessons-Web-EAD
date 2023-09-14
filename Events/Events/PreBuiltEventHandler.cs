using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class StackPublisher : Stack
    {
        public event EventHandler<object> EventHandler;
        public override void Push(object? obj)
        {
            EventHandler(this, obj);
            base.Push(obj);
        }

        public override object? Pop()
        {
            EventHandler(this, base.Peek());
            return base.Pop();
        }
    }

    public class StackSubscriber
    {
        public void PushListener(object? obj, object e)
        {
            Console.WriteLine($"Object Added & EventArgs= {e}");
        }
        public void PopListener(object? obj, object e)
        {
            Console.WriteLine($"Object Removed & EventArgs= {e}");
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
}
