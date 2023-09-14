using Practice_BLL;
using Practice_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_PL
{
    public class Practice_PL_Class
    {
        List<Practice_DTO_Class> newList = new List<Practice_DTO_Class>();
        public void GetDetailFromUser()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Practice_DTO_Class obj = new Practice_DTO_Class { Name = name, Age = age };
            newList.Add(obj);
            Console.WriteLine("Enter Name2: ");
            string name2 = Console.ReadLine();
            Console.WriteLine("Enter Age2: ");
            int age2 = int.Parse(Console.ReadLine());
            Practice_DTO_Class obj2 = new Practice_DTO_Class { Name = name2, Age = age2 };
            newList.Add(obj2);
            Practice_BLL_Class bllObj = new Practice_BLL_Class();
            bllObj.SetCountry(newList);
        }

    }
}
