/*using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    *//*With Sender And Arguements*//*

    delegate void MyEventHandler(object sender,OverrideEventArgs e);
    class OverrideEventArgs : EventArgs
    {
        public int Count { get; set; }
    }
    class ArrayListExamplePublisher : ArrayList
    {
        public event MyEventHandler Added;

        OverrideEventArgs e=new OverrideEventArgs();
        void OnAdded()
        {
            Added(this,e);
        }
        public override int Add(object? value)
        {
            e.Count++;
            OnAdded();
            return base.Add(value);
        }
    }
    class ArrayListExampleSubscriber
    {
        public void Print(object sender,OverrideEventArgs e)
        {
            Console.WriteLine($"Object Is Added By {sender.ToString()} e= {e.Count}");
        }
    }

    public class ArrayListExample
    {
        static void Main()
        {

            ArrayListExamplePublisher objArrayListExamplePublisher = new ArrayListExamplePublisher();
            ArrayListExampleSubscriber objArrayListExampleSubscriber = new ArrayListExampleSubscriber();
            objArrayListExamplePublisher.Added += objArrayListExampleSubscriber.Print;
            objArrayListExamplePublisher.Add(1);
            objArrayListExamplePublisher.Add("4");
        }
    }

*/    /*With Sender*/

    /*delegate void MyEventHandler(object sender);
    class ArrayListExamplePublisher : ArrayList
    {
        public event MyEventHandler Added;

        void OnAdded()
        {
            Added(this);
        }
        public override int Add(object? value)
        {
            OnAdded();
            return base.Add(value);
        }
    }
    class ArrayListExampleSubscriber
    {
        public void Print(object sender)
        {
            Console.WriteLine($"Object Is Added By {sender.ToString()}");
        }
    }

    public class ArrayListExample
    {
        static void Main()
        {

            ArrayListExamplePublisher objArrayListExamplePublisher = new ArrayListExamplePublisher();
            ArrayListExampleSubscriber objArrayListExampleSubscriber = new ArrayListExampleSubscriber();
            objArrayListExamplePublisher.Added += objArrayListExampleSubscriber.Print;
            objArrayListExamplePublisher.Add(1);
            objArrayListExamplePublisher.Add("4");
        }
    }
}*/