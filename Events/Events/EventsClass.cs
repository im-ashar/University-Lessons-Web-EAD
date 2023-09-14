/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1-- > Namespace level par aik delegate bnana hai
//   2--> Uskay bd jis class say event invoke krna usi class mai aik event bnana
//   3--> Us event ki type woo delegate hoo gi jo humnay step 2 mai bnaya
//   4--> Jis class mai event invoke hoo usay publisher class kehtay
//   5-- > Phir aik or class bnani, is class mai sb woo functions rakhny joo 
//        event kay call hoonay pr active hoo gay. In functions ka signature bilkul woi rakhna jo delegate
//        ka hai.
//   6--> Jb dono class ready hoo jain tw main say "event+=subscriberFunName" ko use krkay functions ko subscribe 
//        krwana

namespace Events
{
    delegate void EventHandler();
    internal class Button_Publisher
    {
        public event EventHandler click;

        public void OnClick()
        {
            click();
        }
    }

    internal class Button_Subscriber
    {
        static public void HandleEvent()
        {
            Console.WriteLine("Handle Event Called");
        }
    }
    public class EventsClass
    {
        static void Main()
        {
            Button_Publisher button = new Button_Publisher();
            button.click += Button_Subscriber.HandleEvent;
            button.OnClick();
        }
    }
}
*/