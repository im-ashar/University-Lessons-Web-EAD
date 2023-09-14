using Practice_DTO;
using Practice_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_BLL
{
    public class Practice_BLL_Class
    {
        public void SetCountry(List<Practice_DTO_Class> newList)
        {
            foreach(Practice_DTO_Class x in newList)
            {
                x.Country = "Pakistan";
            }
            Practice_DAL_Class dalObj= new Practice_DAL_Class();
            dalObj.SendForWriting(newList);
        }
    }
}
