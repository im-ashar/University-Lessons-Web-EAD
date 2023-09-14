/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate int MathOp(int x, int y);
    public class Calculator_Delegates
    {
        static int MathOperation(MathOp op, int x, int y) //op asa variable hai jo aik function accept kr skta. yahi delegates ka faida hai k function bhi bhj skty
        {
            return op(x, y);
        }
        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Subtract(int x, int y)
        {
            return x - y;
        }
        static int Multiply(int x, int y)
        {
            return x * y;
        }
        static int Divide(int x, int y)
        {
            return x / y;
        }

        public static void Main()
        {
            //Console.WriteLine(MathOperation(Add, 5, 6));
            //Console.WriteLine(MathOperation(Subtract, 8, 10));
            
            MathOp op = Add;    *//* Is cheez ko kehtay hain multicast delegate*//*
            op += Subtract;     *//*yani aik e object bhut function ko refer kr rha*//*
            op += Divide;       
            op += Multiply;     

            int result = op(5, 8);  //op Add,subtract,divide,multiply sb ko call kray ga lakin result mai answer multiply ka ay ga
                                    //kue kay multiply last mai call hoo rha
                                    //multicast mai jo last pr call hoo ga uski value return hoo gi
            Console.WriteLine(result);

            op -= Subtract; //iska mtlab op ab subtract ko refer ni kray ga 
        }

    }
}
*/