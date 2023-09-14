//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Events
//{
//    delegate void MyEventHandler();
//    internal class ArrayListExamplePublisher : ArrayList
//    {
//        public event MyEventHandler Added;

//        void OnAdded()
//        {
//            Added();
//        }
//        public override int Add(object? value)
//        {
//            OnAdded();
//            return base.Add(value);
//        }
//    }

//    public class ArrayListExample
//    {
//        static void Main()
//        {

//            ArrayListExamplePublisher objArrayListExamplePublisher = new ArrayListExamplePublisher();
//            objArrayListExamplePublisher.Added += () => Console.WriteLine("Object Added");
//            objArrayListExamplePublisher.Add(1);
//            objArrayListExamplePublisher.Add("4");
//        }
//    }
//}