using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Linq2
    {
        /*Linq using lambda expression*/

        //static void Main(string[] args)
        //{
        //    var names = new string[] { "Mustafa", "Shuja", "Zia", "Ibrahim",
        //            "Ali", "Sabir","Azaz" };

        //    var query = names.Where(x => x.Length > 4);

        //    foreach (var n in query)
        //    {
        //        Console.WriteLine(n);
        //    }
        //}



        /*Linq where,select using lambda*/

        //static void Main(string[] args)
        //{
        //    var names = new string[] { "Mustafa", "Shuja", "Zia", "Ibrahim",
        //            "Ali", "Sabir","Azaz" };

        //    var query = names.Where(x => x.Length > 4).Select(n=>n.Substring(0,4));

        //    foreach (var n in query)
        //    {
        //        Console.WriteLine(n);
        //    }
        //}

        /*Linq where,select,orderby using lambda*/

        //static void Main(string[] args)
        //{
        //    var names = new string[] { "Mustafa", "Shuja", "Zia", "Ibrahim",
        //            "Ali", "Sabir","Azaz" };

        //    var query = names.Where(x => x.Length > 4).Select(n => n.Substring(0, 4)).OrderBy(x=>x);

        //    foreach (var n in query)
        //    {
        //        Console.WriteLine(n);
        //    }
        //}

        /*Linq where,select,orderby,thenby using lambda*/

        //static void Main(string[] args)
        //{
        //    var names = new string[] { "Mustafa", "Shuja", "Zia", "Ibrahim",
        //            "Ali", "Sabir","Azaz" };

        //    var query = names.Where(x => x.Length > 4).Select(n => n).OrderBy(x=>x).ThenBy(x=>x.Length);

        //    foreach (var n in query)
        //    {
        //        Console.WriteLine(n);
        //    }
        //}


        /* Linq query as a multiple statement*/

        //iska faida yay hai kay agr koi query kisi condition ki base pr chalani hoo tw chalaa skty

        //static void Main(string[] args)
        //{
        //    var names = new string[] { "Mustafa", "Shuja", "Zia", "Ibrahim",
        //            "Ali", "Sabir","Azaz" };

        //    var query = names.Where(x => x.Length > 4);
        //    query = query.Select(n => n);
        //    query=query.OrderBy(x=>x).ThenBy(x => x.Length);

        //    foreach (var n in query)
        //    {
        //        Console.WriteLine(n);
        //    }
        //} 


        /* Linq query as a multiple statement using condition*/
        //same extension methods aik say zyada dafa bhi use hoo skty same query mai
       
        static void Main(string[] args)
        {
            var names = new string[] { "Mustafa", "Shuja", "Zia", "Ibrahim",
                    "Ali", "Sabir","Azaz" };

            bool value = true;
            var query = names.Where(x => x.Length > 4);
            query = query.Select(n => n);
            if (value)
            {

                query = query.OrderBy(x => x).ThenBy(x => x.Length);
            }
            else
            {
                query = query.OrderByDescending(x => x).ThenBy(x => x.Length);

            }

            foreach (var n in query)
            {
                Console.WriteLine(n);
            }
        }

    }
}
