/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate int MathOp(int x, int y);
    delegate void AnonymousDelegate();
    public class Anonymous_Function
    {
        static void Main()
        {
            //Asa function jo sirf aik jaga use hoona or porray program mai kahi use ni hoona tw aik naya function bnany
            // ki bajay anonymous function bna loo

            MathOp op = delegate (int x, int y) //idhr parameters btany)   //anonymous method ka koi nam ni hoota na hi return type btani
            {
                return x + y;
            };

            Console.WriteLine(op(3, 6));

            //asa function jiski na return type na hi parameter usay bnay ka tariqa
            AnonymousDelegate ad = delegate ()
            {
                Console.WriteLine("Anonymous Delegate Called");
            };
            ad(); //calling ad

           // Anonymous method say bhi multicast kr skty lakin phir -= ni use krskty kue k iskay liay function ka name chahiay
             //or anoymous ka name ni hoota

            //Multicasting Using Anonymous Methods

            MathOp op2 = delegate (int x, int y)
            {
                return x + y;
            };

            op2 += delegate (int x, int y)
            {
                return x - y;
            };

            Console.WriteLine(op2(6, 7));

           // Lambda Statement

            op2 += (int x, int y) => { return x * y; }; //lamda statment mai delegate ka keyword bhi remove krdena
                                                        //Or parameters ki datatype btany ki bhi zarurat ni hai like
                                                        //op2 += (x, y) => { return x * y; };
            op2 += (x, y) => { return x * y; };

           // Lamda Expression

            op2 += (x, y) => x * y; //yay tb hi use kr skty jb koi aik e statement ani hoo function mai

            ad = () => Console.WriteLine("Hello");
            ad();
        }

    }
}

*/