/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    delegate void MyEventHandler(string s);
    internal class Email_Message_Example_Publisher
    {
        public event MyEventHandler objMyEventHandler;
        public void OnSendMessage(string msg)
        {
            Console.WriteLine("Sending Message");
            objMyEventHandler(msg);
        }
    }
    internal class Email_Message_Example_Subscriber
    {
        public void SendEmail(string msg)
        {
            Console.WriteLine($"Email Send {msg}");
        }
        public void SendMessage(string msg)
        {
            Console.WriteLine($"Message Send {msg}");
        }
    }
    internal class Email_Message_Example
    {
        static void Main()
        {
            Email_Message_Example_Publisher objEmail_Message_Example_Publisher = new Email_Message_Example_Publisher();
            Email_Message_Example_Subscriber objEmail_Message_Example_Subscriber = new Email_Message_Example_Subscriber();
            objEmail_Message_Example_Publisher.objMyEventHandler += objEmail_Message_Example_Subscriber.SendEmail;
            objEmail_Message_Example_Publisher.objMyEventHandler += objEmail_Message_Example_Subscriber.SendMessage;
            objEmail_Message_Example_Publisher.OnSendMessage("Successfully");
        }
    }

}
*/