/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    *//*Asay Function ko point kray ga jinki return type void hai or koi parameter nai receive krtay
     Jaisy Display1 ka function is case mai*//*
    delegate void Delegate1();

    *//*Asay Function ko point kray ga jinki return type void hai lakin koi aik string type ka parameter receive krty hain
     Jaisy Display2 ka function is case mai*//*
    delegate void Delegate2(string s);

    *//*Asay Function ko point kray ga jinki return type string hai lakin koi aik string type ka parameter receive krty hain
     Jaisy Display3 ka function is case mai*//*
    delegate string Delegate3(string s);

    delegate int Delegate4(int i);
    public class Delegates_Practice
    {
        static void Display1()
        {
            Console.WriteLine("Calling From Delegate With No Return Type And No Parameters");
        }

        static void Display2(string s)
        {
            Console.WriteLine(s);
        }
        static string Display3(string s)
        {
            Console.WriteLine(s);
            return s;
        }
        static int Display4(int i)
        {
            Console.WriteLine(i);
            return i;
        }
        static int Display5(int i)
        {
            Console.WriteLine(i);
            return i;
        }
        static public void Main()
        {
            *//*Calling Function With Delegate*//*

            //Creating Object Of Delegate1 and setting that this object will refer which function
            Delegate1 objDelegate1 = new Delegate1(Display1); //OR Delegate1 objDelegate1=Display
            //calling
            objDelegate1.Invoke(); //OR objDelegate1();


            Delegate2 objDelegate2 = new Delegate2(Display2);
            objDelegate2.Invoke("Ashar"); //kue kay yay asy function ko point kr rha jo aik string receive krta hai tw hamain bhjni hooo gi woo string


            Delegate3 objDelegate3 = new Delegate3(Display3);
            string s = objDelegate3("Delegate3");

            Delegate4 objDelegate4=null; //aik e type kay 2 function hain or hamain nai pata knsa run krna tw null object banao
                                    //or bd mai batao knsa run hona based on condition
            
            int i = int.Parse(Console.ReadLine());
            if (i == 4)
            {
                objDelegate4 = Display4;

            }
            if(i== 5)
            {
                objDelegate4 = Display5;
            }
            objDelegate4.Invoke(i);
        }
    }
}
*/